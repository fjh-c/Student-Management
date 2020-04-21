using System;
using System.Collections.Generic;

namespace Student.DTO
{
    public class StudentInfoDTO
    {
        /// <summary>
        /// 学生编号
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 学生姓名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        public string Sex { get; set; }
        /// <summary>
        /// 民族
        /// </summary>
        public string NationId { get; set; }
        /// <summary>
        /// 电话
        /// </summary>
        public string Phone { get; set; }
        /// <summary>
        /// 邮箱
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// 身份证号码
        /// </summary>
        public string PersonId { get; set; }
        /// <summary>
        /// 家庭地址
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// 学生照片
        /// </summary>
        public string Photos { get; set; }
        /// <summary>
        /// 激活状态
        /// </summary>
        public int Status { get; set; }
    }
}
