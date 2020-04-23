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
    public partial class Admin : EntityBase
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

    }
}
