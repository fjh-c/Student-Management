using System;
using System.Collections.Generic;
using System.Text;

namespace Student.DTO.Login
{
    public class LoginResultDTO
    {
        /// <summary>
        /// 账户信息
        /// </summary>
        public AccountDTO Account { get; set; }

        /// <summary>
        /// 认证信息
        /// </summary>
        public AuthInfoDTO AuthInfo { get; set; }
    }
}
