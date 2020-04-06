using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Student.Model
{
    /// <summary>
    /// 民族表
    /// </summary>
    [Table("Nation")]
    public class Nation: EntityBase
    {
        public string Name { get; set; }
        /// <summary>
        /// 排除特定属性
        /// </summary>
        [NotMapped]
        public override int Status { get; set; }
    }
}
