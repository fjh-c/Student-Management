using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Student.DTO;
using Student.DTO.Login;
using Student.IServices;
using Student.Model;
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

        public AuthInfoService(Lazy<IMapper> mapper, IUnitOfWork unitOfWork, ILogger<AuthInfoService> logger,
            Lazy<IRepository<AuthInfo>> _repository, Lazy<IRepository<Account>> repAccount) : base(mapper, unitOfWork, logger, _repository)
        {
            this.repAccount = repAccount;
        }

        public async Task<IResultModel> Login(LoginModel model)
        {
            var entity = await repAccount.Value.TableNoTracking.FirstAsync(p => p.UserName == model.UserName.Trim() && p.PassWord == model.Password);
            if (entity == null)
            {
                return ResultModel.Failed("用户名密码错误");
            }

            //更新认证信息并返回登录结果
            return ResultModel.Success(entity);
        }

        public IResultModel CreateVerifyCode(int length = 6)
        {
            var model = new VerifyCodeModel
            {
                Id = Guid.NewGuid().ToString(),
                Code = ValidateCodeHelper.CreateBase64String(out string code, length)
            };

            //把验证码放到内存缓存中，有效期10分钟
            //var key = $"{CacheKeys.AUTH_VERIFY_CODE}:{model.Id}";
            //_cacheHandler.SetAsync(key, code, 10);

            return ResultModel.Success(model);
        }

        public IResultModel Check(LoginModel model)
        {
            if (model.VerifyCode == null || model.VerifyCode.Code.IsNull())
                return ResultModel.Failed("请输入验证码");

            if (model.VerifyCode.Id.IsNull())
                return ResultModel.Failed("验证码不存在");

            //var cacheCode = _cacheHandler.GetAsync($"{CacheKeys.AUTH_VERIFY_CODE}:{model.VerifyCode.Id}").Result;
            //if (cacheCode.IsNull())
            //    return ResultModel.Failed("验证码不存在");

            //if (!cacheCode.Equals(model.VerifyCode.Code))
            //    return ResultModel.Failed("验证码有误");

            return ResultModel.Success();
        }
    }
}
