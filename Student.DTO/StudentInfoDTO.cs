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
        [Description("学生编号")]
        public long Id { get; set; }
        [Description("激活状态")]
        public int Status { get; set; }
        [Description("学生姓名")]
        [Required]
        public string Name { get; set; }
        [Description("学生性别")]
        public int Gender { get; set; }
        [Description("学生民族")]
        public int Nation { get; set; }
        [Description("入学时间")]
        [DataType(DataType.Date)]
        public DateTime EnrollmentDT { get; set; }
        [Description("学生部门")]
        public int DepartId { get; set; }
        [Description("学生电话")]
        [Phone]
        public string Phone { get; set; }
        [Description("学生邮箱")]
        [EmailAddress]
        public string Email { get; set; }
        [Description("身份证号码")]
        [Required]
        public string PersonId { get; set; }
        [Description("学生地址")]
        public string Address { get; set; }
        [Description("学生照片")]
        public string Photos { get; set; }
        [Description("学生性别")]
        public string GenderName { get; set; }
        [Description("民族显示")]
        public string NationName { get; set; }
        [Description("部门显示")]
        public string DepartName { get; set; }
    }
}
