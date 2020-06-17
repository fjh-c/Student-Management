﻿using AutoMapper;
using AutoMapper.QueryableExtensions;
using Cache.MemoryCache;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Student.DTO;
using Student.DTO.Login;
using Student.IServices;
using Student.Model;
using Student.Model.Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using yrjw.CommonToolsCore.Helper;
using yrjw.ORM.Chimp;
using yrjw.ORM.Chimp.Result;

namespace Student.Services
{
    public class AuthInfoService : BaseService<AuthInfo, AuthInfoDTO, int>, IAuthInfoService, IDependency
    {
        private readonly Lazy<IRepository<Account>> repAccount;

        public AuthInfoService(Lazy<IMapper> mapper, IUnitOfWork unitOfWork, ILogger<AuthInfoService> logger, Lazy<ICacheHandler> cacheHandler,
            Lazy<IRepository<AuthInfo>> _repository, Lazy<IRepository<Account>> repAccount) : base(mapper, unitOfWork, logger, cacheHandler, _repository)
        {
            this.repAccount = repAccount;
        }

        public async Task<IResultModel> Login(LoginModel model)
        {
            //检测验证码
            var verifyCodeCheckResult = CheckVerifyCode(model);
            if (!verifyCodeCheckResult.Success)
                return verifyCodeCheckResult;

            //检查账户密码
            var entity = await repAccount.Value.TableNoTracking.FirstAsync(p => p.UserName == model.UserName.Trim());
            if (entity == null)
            {
                return ResultModel.Failed("用户名密码错误"); //用户不存在
            }

            var _passWord = $"{model.UserName}_{model.Password}".ToMd5Hash();
            if (!_passWord.Equals(entity.PassWord))
            {
                return ResultModel.Failed("用户名密码错误");
            }

            //更新认证信息并返回登录结果
            var resultModel = await UpdateAuthInfo(entity, model);
            if (resultModel != null)
            {
                return ResultModel.Success(resultModel);
            }
            return ResultModel.Failed("更新认证信息失败");
        }

        public async Task<IResultModel> CreateVerifyCode(int length = 4)
        {
            var model = new VerifyCodeModel
            {
                Id = Guid.NewGuid().ToString(),
                Code = ValidateCodeHelper.CreateBase64String(out string code, length)
            };

            //把验证码放到内存缓存中，有效期10分钟
            var key = $"{CacheKeys.AUTH_VERIFY_CODE}:{model.Id}";
            await _cacheHandler.Value.SetAsync(key, code, 10);

            return ResultModel.Success(model);
        }

        /// <summary>
        /// 刷新令牌
        /// </summary>
        /// <param name="refreshToken"></param>
        /// <returns></returns>
        public async Task<IResultModel> RefreshToken(string refreshToken)
        {
            var cacheKey = CacheKeys.AUTH_REFRESH_TOKEN + refreshToken;
            if (!_cacheHandler.Value.TryGetValue(cacheKey, out AuthInfoDTO authInfoDTO))
            {
                var authInfo = await _repository.Value.TableNoTracking.FirstOrDefaultAsync(p=>p.RefreshToken==refreshToken);
                if (authInfo == null)
                    return ResultModel.Failed("身份认证信息无效，请重新登录");
                authInfoDTO = _mapper.Value.Map<AuthInfoDTO>(authInfo);

                //加入缓存
                var expires = (int)(authInfo.RefreshTokenExpiredTime - DateTime.Now).TotalMinutes;
                await _cacheHandler.Value.SetAsync(cacheKey, authInfoDTO, expires);
            }

            if (authInfoDTO.RefreshTokenExpiredTime <= DateTime.Now)
                return ResultModel.Failed("身份认证信息过期，请重新登录~");

            var account = await repAccount.Value.GetByIdAsync(authInfoDTO.AccountId);
            if (account == null)
                return ResultModel.Failed("账户信息不存在");

            var accountDTO = _mapper.Value.Map<AccountDTO>(account);
            if (account.Status != Model.Enums.EnumStatus.Enabled)
                return ResultModel.Failed($"账户状态：{accountDTO.StatusName}");
            
            return ResultModel.Success(new LoginResultDTO
            {
                Account = accountDTO,
                AuthInfo = authInfoDTO
            });
        }

        private IResultModel CheckVerifyCode(LoginModel model)
        {
            if (model.VerifyCode == null || model.VerifyCode.Code.IsNull())
                return ResultModel.Failed("请输入验证码");

            if (model.VerifyCode.Id.IsNull())
                return ResultModel.Failed("验证码不存在");

            var cacheCode = _cacheHandler.Value.GetAsync($"{CacheKeys.AUTH_VERIFY_CODE}:{model.VerifyCode.Id}").Result;
            if (cacheCode.IsNull())
                return ResultModel.Failed("验证码不存在");

            if (!cacheCode.Equals(model.VerifyCode.Code))
                return ResultModel.Failed("验证码有误");
            return ResultModel.Success();
        }

        /// <summary>
        /// 更新账户认证信息
        /// </summary>
        private async Task<LoginResultDTO> UpdateAuthInfo(Account account, LoginModel model)
        {
            var accountDTO = _mapper.Value.Map<AccountDTO>(account);
            var authInfo = new AuthInfoDTO
            {
                AccountId = account.Id,
                Platform = model.Platform,
                LoginTime = DateTime.Now.ToTimestamp(),
                LoginIP = model.IP,
                RefreshToken = GenerateRefreshToken(),
                RefreshTokenExpiredTime = DateTime.Now.AddDays(7)//默认刷新令牌有效期7天
            };

            IResultModel result;
            var entity = _repository.Value.TableNoTracking.FirstOrDefault(p => p.AccountId == account.Id && p.Platform == model.Platform);
            if (entity != null)
            {
                authInfo.Id = entity.Id;
                result = await base.UpdateAsync(authInfo);
            }
            else
            {
                result = await base.InsertAsync(authInfo);
            }

            if (result.Success)
            {
                //删除验证码缓存
                await _cacheHandler.Value.RemoveAsync($"{CacheKeys.AUTH_VERIFY_CODE}:{model.VerifyCode.Id}");

                //清除账户的认证信息缓存
                await _cacheHandler.Value.RemoveAsync($"{CacheKeys.ACCOUNT_AUTH_INFO}:{account.Id}:{model.Platform.ToInt()}");

                return new LoginResultDTO
                {
                    Account = accountDTO,
                    AuthInfo = authInfo
                };
            }
            return null;
        }

        /// <summary>
        /// 生成刷新令牌
        /// </summary>
        /// <returns></returns>
        private string GenerateRefreshToken()
        {
            return Guid.NewGuid().ToString().Replace("-", "");
        }
    }
}