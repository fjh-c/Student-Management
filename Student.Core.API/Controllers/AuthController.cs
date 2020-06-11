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

        public AuthController(ILogger<ControllerAbstract> logger, ILoginHandler loginHandler) : base(logger)
        {
            _loginHandler = loginHandler;
        }

        public Lazy<IAuthInfoService> AuthInfoService { get; set; }

        [HttpGet("VerifyCode")]
        [AllowAnonymous]
        [Description("获取验证码")]
        public IResultModel VerifyCode(int length = 6)
        {
            return AuthInfoService.Value.CreateVerifyCode(length);
        }

        [HttpPost("Login")]
        [AllowAnonymous]
        [Description("用户名登录")]
        public async Task<IResultModel> Login(LoginModel model)
        {
            return await Task.FromResult<IResultModel>(null);
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
