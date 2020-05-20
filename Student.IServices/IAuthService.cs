using Student.DTO.Login;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using yrjw.ORM.Chimp.Result;

namespace Student.IServices
{
    /// <summary>
    /// 身份认证服务接口
    /// </summary>
    public class IAuthService
    {
        /// <summary>
        /// 创建验证码图片
        /// </summary>
        /// <param name="length">验证码长度</param>
        /// <returns></returns>
        //IResultModel CreateVerifyCode(int length = 6);

        /// <summary>
        /// 用户名登录
        /// </summary>
        /// <param name="model">登录模型</param>
        /// <returns></returns>
        //Task<ResultModel<LoginResultModel>> Login(LoginModel model);

    }
}
