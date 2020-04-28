using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Student.Model.Enums
{
    /// <summary>
    /// 激活状态
    /// </summary>
    public enum EnumStatus
    {
        /// <summary>
        /// 未激活
        /// </summary>
        [Description("未激活")]
        Inactive,
        /// <summary>
        /// 正常
        /// </summary>
        [Description("正常")]
        Enabled,
        /// <summary>
        /// 禁用
        /// </summary>
        [Description("禁用")]
        Disabled,
        /// <summary>
        /// 注销
        /// </summary>
        [Description("注销")]
        Closed
    }
}
