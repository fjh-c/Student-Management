﻿using Student.DTO.Attributes;
using Student.Model;
using Student.Model.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Student.DTO
{
    [Description("配置")]
    public class ConfigDTO
    {
        /// <summary>
        /// 配置编号
        /// </summary>
        [Display(Name = "配置编号")]
        public int Id { get; set; }
        /// <summary>
        /// 配置代码
        /// </summary>
        [Display(Name = "配置代码")]
        [Required(ErrorMessage = "{0} 不能为空")]
        public string Code { get; set; }
        /// <summary>
        /// 配置脚本
        /// </summary>
        [Display(Name = "配置脚本")]
        public string Value { get; set; }
    }
}
