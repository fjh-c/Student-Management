using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Student.Model
{
    [NotMapped]
    public partial class StudentInfo
    {
        /// <summary>
        /// 性别展示
        /// </summary>
        public string GenderName => Gender.ToDescription();
        /// <summary>
        /// 民族展示
        /// </summary>
        public string NationName => Nation.ToDescription();
    }
}
