using Student.Model.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Student.Model
{
    /// <summary>
    /// 管理员表
    /// </summary>
    [Table("Admin")]
    public partial class Admin : EntityBaseNoDeleted
    {
        /// <summary>
        /// 管理员账号
        /// </summary>
        [Required]
        [Column(TypeName = "varchar(50)")]
        public string UserName { get; set; }

        /// <summary>
        /// 管理员密码
        /// </summary>
        [Required]
        [Column(TypeName = "varchar(50)")]
        public string PassWord { get; set; }

        [NotMapped]
        public override DateTime CreatedTime { get => base.CreatedTime; set => base.CreatedTime = value; }
        [NotMapped]
        public override string OperatorName { get => base.OperatorName; set => base.OperatorName = value; }

    }
}
