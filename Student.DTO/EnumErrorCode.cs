using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Student.DTO
{
    /// <summary>
    /// 返回错误码
    /// </summary>
    public enum EnumErrorCode
    {
        /// <summary>
        /// 默认
        /// </summary>
        None = -1,
        /// <summary>
        /// 外键不存在，或部门必须指定班级
        /// </summary>
        [Description("外键不存在，或部门必须指定班级")]
        Departid = -10001,
        /// <summary>
        /// 该手机号已被其他账号绑定使用
        /// </summary>
        [Description("该手机号已被其他账号绑定使用")]
        Phone = -10002,
        /// <summary>
        /// 该身份证号已被其他账号绑定使用
        /// </summary>
        [Description("该身份证号已被其他账号绑定使用")]
        [Display(Name = "禁用")]
        IdentityCard = -10003,
        /// <summary>
        /// 用户名已存在
        /// </summary>
        [Description("用户名已存在")]
        UserName = -10004,
        /// <summary>
        /// 初始化数据不能删除
        /// </summary>
        [Description("初始化数据不能删除")]
        DeleteProhibited = -10005
    }
}
