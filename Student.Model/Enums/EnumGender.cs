using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Student.Model.Enums
{
    public enum EnumGender
    {
        [Description("未知")]
        UnKnown = -1,
        /// <summary>
        /// 男
        /// </summary>
        [Description("男")]
        Man,
        /// <summary>
        /// 女
        /// </summary>
        [Description("女")]
        Woman
    }
}
