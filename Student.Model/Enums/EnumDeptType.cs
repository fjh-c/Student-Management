using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Student.Model.Enums
{
    /// <summary>
    /// 部门类别
    /// </summary>
    public enum EnumDeptType
    {
        /// <summary>
        /// 年组
        /// </summary>
        [Description("年组")]
        grade,
        /// <summary>
        /// 班级
        /// </summary>
        [Description("班级")]
        classes
    }
}
