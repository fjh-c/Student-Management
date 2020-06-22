using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using yrjw.CommonToolsCore.Attributes;

namespace Auth.Jwt
{
    [Singleton]
    public class JwtLoginHandler : ILoginHandler
    {
        private readonly ILogger _logger;

        public JwtLoginHandler(ILogger<JwtLoginHandler> logger)
        {
            _logger = logger;
        }

        public JwtTokenModel Hand(List<Claim> claims, string extendData)
        {
            var options = AuthConfigData.AuthConfig.Jwt;
            var token = Build(claims, options);

            _logger.LogDebug("生成JwtToken：{token}", token);

            var model = new JwtTokenModel
            {
                AccessToken = token,
                ExpiresIn = options.Expires * 60,
                RefreshToken = extendData
            };

            return model;
        }

        private string Build(List<Claim> claims, JwtConfig config)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config.Key));
            var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(config.Issuer, config.Audience, claims, DateTime.Now, DateTime.Now.AddMinutes(config.Expires), signingCredentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
