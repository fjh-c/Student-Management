using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Auth.Jwt;
using Cache.MemoryCache;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Logging;
using Student.Core.API.Code.WebApi;
using Student.DTO;
using Student.DTO.Login;
using Student.IServices;
using yrjw.ORM.Chimp.Result;

namespace Student.Core.API.Controllers
{
    [Description("身份认证")]
    public class AuthController : ControllerAbstract
    {
        private readonly ILoginHandler _loginHandler;
        private readonly IpHelper _ipHelper;

        public AuthController(ILogger<ControllerAbstract> logger, ILoginHandler loginHandler, IpHelper ipHelper) : base(logger)
        {
            _loginHandler = loginHandler;
            _ipHelper = ipHelper;
        }

        public Lazy<IAuthInfoService> AuthInfoService { get; set; }

        [HttpGet("VerifyCode")]
        [AllowAnonymous]
        [Description("获取验证码")]
        public IResultModel VerifyCode(int length = 4)
        {
            return AuthInfoService.Value.CreateVerifyCode(length);
        }

        [HttpPost("Login")]
        [AllowAnonymous]
        [Description("用户名登录")]
        public async Task<IResultModel> Login(LoginModel model)
        {
            model.IP = _ipHelper.IP;
            model.UserAgent = _ipHelper.UserAgent;
            var result = await AuthInfoService.Value.Login(model);
            return LoginHandle(result);
        }

        /// <summary>
        /// 登录处理
        /// </summary>
        private IResultModel LoginHandle(IResultModel result)
        {
            if (result.Success)
            {
                var model = result as ResultModel<LoginResultDTO>;
                var account = model.Data.Account;
                var loginInfo = model.Data.AuthInfo;
                var claims = new List<Claim>
                {
                    new Claim(ClaimsName.AccountId, account.Id.ToString()),
                    new Claim(ClaimsName.AccountName, account.Name),
                    new Claim(ClaimsName.AccountType, account.Type.ToInt().ToString()),
                    new Claim(ClaimsName.Platform, loginInfo.Platform.ToInt().ToString()),
                    new Claim(ClaimsName.LoginTime, loginInfo.LoginTime.ToString())
                };
                var jwtmodel = _loginHandler.Hand(claims, loginInfo.RefreshToken);
                return ResultModel.Success(jwtmodel);
            }
            return ResultModel.Failed(result.Msg);
        }

        [HttpGet("RefreshToken")]
        [AllowAnonymous]
        [Description("刷新令牌")]
        public async Task<IResultModel> RefreshToken([BindRequired]string refreshToken)
        {
            //var result = await _service.RefreshToken(refreshToken);
            //return LoginHandle(result);
            return await Task.FromResult<IResultModel>(null);
        }

        [HttpGet("AuthInfo")]
        //[Common]
        [Description("获取认证信息")]
        public Task<IResultModel> AuthInfo()
        {
            return Task.FromResult<IResultModel>(null);
        }
    }
}
