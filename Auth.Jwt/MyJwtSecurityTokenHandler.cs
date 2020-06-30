using Microsoft.IdentityModel.Tokens;
using Student.DTO;
using Student.IServices;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using yrjw.ORM.Chimp.Result;

namespace Auth.Jwt
{
    /// <summary>
    /// 因为签名的key是动态的，所以需要自定义jwt令牌验证处理器
    /// </summary>
    public class MyJwtSecurityTokenHandler : JwtSecurityTokenHandler, ISecurityTokenValidator
    {
        private readonly IConfigService _configService;
        public MyJwtSecurityTokenHandler(IConfigService configService)
        {
            _configService = configService;
        }
        public override ClaimsPrincipal ValidateToken(string token, TokenValidationParameters validationParameters,
            out SecurityToken validatedToken)
        {
            var config = _configService.GetValue("Auth").GetAwaiter().GetResult() as ResultModel<ConfigDTO>;
            if (config.Success)
            {
                AuthConfigData.AuthConfig = config.Data.Value.ToJson<AuthConfigData>();
            }
            var jwtConfig = AuthConfigData.AuthConfig.Jwt;

            validationParameters.ValidIssuer = jwtConfig.Issuer;
            validationParameters.ValidAudience = jwtConfig.Audience;
            validationParameters.IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtConfig.Key));

            return base.ValidateToken(token, validationParameters, out validatedToken);
        }
    }
}
