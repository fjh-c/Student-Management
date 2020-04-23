using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManageSystem.ViewModels.Enums
{
    /// <summary>
    /// 部门类别
    /// </summary>
    public enum EnumDeptType
    {
        /// <summary>
        /// 年组
        /// </summary>
        [Display(Name ="年组")]
        grade,
        /// <summary>
        /// 班级
        /// </summary>
        [Display(Name = "班级")]
        classes
    }
}
