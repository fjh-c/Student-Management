﻿using yrjw.ORM.Chimp;
using System.Threading.Tasks;
using yrjw.ORM.Chimp.Result;
using Student.DTO;
using Student.Model;
using Student.DTO.Login;

namespace Student.IServices
{
    public interface IAuthInfoService : IBaseService<AuthInfo, AuthInfoDTO, int>
    {
        /// <summary>
        /// 登录处理
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<IResultModel> Login(LoginModel model);

        /// <summary>
        /// 创建验证码
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        IResultModel CreateVerifyCode(int length = 6);
    }
}
