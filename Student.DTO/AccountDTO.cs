using Microsoft.AspNetCore.Http;
using Student.DTO.Attributes;
using Student.Model;
using Student.Model.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Student.DTO
{
    public class AccountDTO
    {
        /// <summary>
        /// 编号
        /// </summary>
        [Display(Name = "编号")]
        public Guid Id { get; set; } = Guid.NewGuid();

        /// <summary>
        /// 账号
        /// </summary>
        [Display(Name = "账号")]
        [Required(ErrorMessage = "{0},不能为空")]
        [StringLength(18, ErrorMessage = "{0},不能大于{1}")]
        public string UserName { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        [Display(Name = "密码")]
        [Required(ErrorMessage = "{0},不能为空")]
        [StringLength(11, ErrorMessage = "{0},不能大于{1}")]
        public string PassWord { get; set; }

        /// <summary>
        /// 类型
        /// </summary>
        [Display(Name = "类型")]
        public EnumAccountType Type { get; set; }

        /// <summary>
        /// 昵称
        /// </summary>
        [Display(Name = "昵称")]
        [Required(ErrorMessage = "{0},不能为空")]
        [StringLength(7, ErrorMessage = "{0},不能大于{1}")]
        public string Name { get; set; }

        /// <summary>
        /// 激活状态
        /// </summary>
        [Display(Name = "激活状态")]
        public EnumStatus Status { get; set; }

        /// <summary>
        /// 修改时间
        /// </summary>
        [Display(Name = "修改时间")]
        [IgnoreProperty]
        public string ModifiedTime { get; set; }

        /// <summary>
        /// 类型展示
        /// </summary>
        [IgnoreProperty]
        public string TypeName { get; set; }

    }
}
