using Student.Model.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Student.Model
{
    /// <summary>
    /// 学生信息表
    /// </summary>
    [Table("StudentInfo")]
    public partial class StudentInfo: EntityBase
    {
        /// <summary>
        /// 学生姓名
        /// </summary>
        [Required]
        [Column(TypeName = "varchar(50)")]
        public string Name { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        public EnumGender Gender { get; set; }
        /// <summary>
        /// 民族
        /// </summary>
        public EnumNation Nation { get; set; } = EnumNation.hanzu;
        /// <summary>
        /// 电话
        /// </summary>
        public string Phone { get; set; }
        /// <summary>
        /// 邮箱
        /// </summary>
        [Column(TypeName = "varchar(50)")]
        public string Email { get; set; }
        /// <summary>
        /// 身份证号码
        /// </summary>
        [Required]
        public string PersonId { get; set; }
        /// <summary>
        /// 家庭地址
        /// </summary>
        [Column(TypeName = "varchar(200)")]
        public string Address { get; set; }
        /// <summary>
        /// 学生照片
        /// </summary>
        public string Photos { get; set; }

    }
}
