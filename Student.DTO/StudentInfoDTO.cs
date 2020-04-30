using Student.Model;
using Student.Model.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Student.DTO
{
    public class StudentInfoDTO
    {
        /// <summary>
        /// 学生编号
        /// </summary>
        [Display(Name = "学生编号")]
        public long Id { get; set; }
        /// <summary>
        /// 学生姓名
        /// </summary>
        [Display(Name = "学生姓名")]
        [Required(ErrorMessage ="{0} 不能为空")]
        public string Name { get; set; }
        /// <summary>
        /// 学生性别
        /// </summary>
        [Display(Name = "学生性别")]
        public EnumGender Gender { get; set; }
        /// <summary>
        /// 学生民族
        /// </summary>
        [Display(Name = "学生民族")]
        public EnumNation Nation { get; set; }
        /// <summary>
        /// 入学时间
        /// </summary>
        [Display(Name = "入学时间")]
        [Required(ErrorMessage = "{0} 不能为空")]
        [DataType(DataType.Date)]
        public string EnrollmentDT { get; set; }
        /// <summary>
        /// 学生部门
        /// </summary>
        [Display(Name = "学生部门")]
        [Required(ErrorMessage = "{0} 不能为空")]
        public int DepartId { get; set; }
        /// <summary>
        /// 学生电话
        /// </summary>
        [Display(Name = "学生电话")]
        [Required(ErrorMessage = "{0} 不能为空")]
        [Phone(ErrorMessage = "电话号码 格式不正确")]
        public string Phone { get; set; }
        /// <summary>
        /// 学生邮箱
        /// </summary>
        [Display(Name = "学生邮箱")]
        [Required(ErrorMessage = "{0} 不能为空")]
        [EmailAddress(ErrorMessage = "邮箱地址 格式不正确")]
        public string Email { get; set; }
        /// <summary>
        /// 身份证号码
        /// </summary>
        [Display(Name = "身份证号码")]
        [Required(ErrorMessage = "{0} 不能为空")]
        public string PersonId { get; set; }
        /// <summary>
        /// 学生地址
        /// </summary>
        [Display(Name = "学生地址")]
        public string Address { get; set; }
        /// <summary>
        /// 学生照片
        /// </summary>
        [Display(Name = "学生照片")]
        public string Photos { get; set; }
        /// <summary>
        /// 激活状态
        /// </summary>
        [Display(Name = "激活状态")]
        public EnumStatus Status { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        [Display(Name = "创建时间")]
        public string CreatedTime { get; set; }
        /// <summary>
        /// 修改时间
        /// </summary>
        [Display(Name = "修改时间")]
        public string ModifiedTime { get; set; }
        /// <summary>
        /// "操作人名称
        /// </summary>
        [Display(Name = "操作人名称")]
        public string OperatorName { get; set; }

        /// <summary>
        /// 性别展示
        /// </summary>
        public string GenderName { get; set; }
        /// <summary>
        /// 民族展示
        /// </summary>
        public string NationName { get; set; }
        /// <summary>
        /// 激活状态展示
        /// </summary>
        public string StatusName { get; set; }
        /// <summary>
        /// 部门展示
        /// </summary>
        public string DepartName { get; set; }
    }
}
