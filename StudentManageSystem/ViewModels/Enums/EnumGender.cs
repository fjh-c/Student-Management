using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManageSystem.ViewModels.Enums
{
    /// <summary>
    /// 性别
    /// </summary>
    public enum EnumGender
    {
        [Display(Name = "未知")]
        UnKnown = -1,
        /// <summary>
        /// 男
        /// </summary>
        [Display(Name = "男")]
        Man,
        /// <summary>
        /// 女
        /// </summary>
        [Display(Name = "女")]
        Woman
    }
}
