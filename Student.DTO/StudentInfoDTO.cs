using Student.Model;
using Student.Model.Enums;
using System;
using System.Collections.Generic;

namespace Student.DTO
{
    public class StudentInfoDTO
    {
        /// <summary>
        /// 编号
        /// </summary>
        public long Id { get; set; }
        /// <summary>
        /// 激活状态
        /// </summary>
        public int Status { get; set; }
        /// <summary>
        /// 学生姓名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 学生性别
        /// </summary>
        public EnumGender Gender { get; set; }
        /// <summary>
        /// 学生民族
        /// </summary>
        public EnumNation Nation { get; set; }
        /// <summary>
        /// 入学时间
        /// </summary>
        public DateTime EnrollmentDT { get; set; }
        /// <summary>
        /// 部门
        /// </summary>
        public int DepartId { get; set; }
        /// <summary>
        /// 学生电话
        /// </summary>
        public string Phone { get; set; }
        /// <summary>
        /// 学生邮箱
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// 身份证号码
        /// </summary>
        public string PersonId { get; set; }
        /// <summary>
        /// 学生地址
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// 学生照片
        /// </summary>
        public string Photos { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        public string GenderName { get; set; }
        /// <summary>
        /// 民族
        /// </summary>
        public string NationName { get; set; }
        /// <summary>
        /// 部门名称
        /// </summary>
        public string DepartName { get; set; }
    }
}
