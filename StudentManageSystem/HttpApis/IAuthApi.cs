using Student.DTO.Login;
using StudentManageSystem.ViewModels;
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

        /// <summary>
        /// 登录处理
        /// </summary>
        /// <returns></returns>
        [HttpPost("api/Auth/Login")]
        ITask<ResultModel<JwtTokenModel>> Login([JsonContent]LoginModel model);
    }
}
