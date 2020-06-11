using Student.DTO;
using Student.DTO.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiClient;
using WebApiClient.Attributes;
using yrjw.ORM.Chimp.Result;

namespace StudentManageSystem.HttpApis
{
    [JsonReturn]
    public interface IAuthApi : IHttpApi
    {
        /// <summary>
        /// 获取验证码
        /// </summary>
        /// <returns></returns>
        [HttpGet("api/Auth/VerifyCode")]
        ITask<ResultModel<VerifyCodeModel>> GetVerifyCode(int length);


    }
}
