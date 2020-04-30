using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Student.Model
{
    [NotMapped]
    public partial class Depart
    {
        /// <summary>
        /// 部门类别展示
        /// </summary>
        public string DeptTypeName => DeptType.ToDescription();
    }
}
