using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManageSystem.ViewModels
{
    public class StudentInfoViewModel
    {
        [DisplayName("学生编号")]
        public int Id { get; set; }
        [DisplayName("学生姓名")]
        public string Name { get; set; }
        [DisplayName("学生性别")]
        public string Sex { get; set; }
        [DisplayName("学生民族")]
        public string NationId { get; set; }
        [DisplayName("学生电话")]
        public string Phone { get; set; }
        [DisplayName("学生邮箱")]
        public string Email { get; set; }
        [DisplayName("身份证号码")]
        public string PersonId { get; set; }
        [DisplayName("学生住址")]
        public string Address { get; set; }
        [DisplayName("学生照片")]
        public string Photos { get; set; }
        [DisplayName("激活状态")]
        public int Status { get; set; }
    }
}
