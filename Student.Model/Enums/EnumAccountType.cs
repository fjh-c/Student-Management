using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Student.Model.Enums
{
    /// <summary>
    /// 账户类型
    /// </summary>
    public enum EnumAccountType
    {
        /// <summary>
        /// 系统操作员
        /// </summary>
        [Description("系统操作员")]
        Admin,
        /// <summary>
        /// 用户
        /// </summary>
        [Description("用户")]
        User
    }
}
