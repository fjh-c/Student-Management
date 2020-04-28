﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using yrjw.ORM.Chimp;

namespace Student.Model
{
    /// <summary>
    /// 数据模型标准int
    /// </summary>
    public class EntityBase: EntityBase<int> 
    {

    }

    /// <summary>
    /// 数据模型标准, 无软删除
    /// </summary>
    public class EntityBaseNoDeleted : EntityBase<int>
    {
        [NotMapped]
        public override int Deleted { get => base.Deleted; set => base.Deleted = value; }
    }

    /// <summary>
    /// 数据模型标准, 无软删除
    /// </summary>
    /// <typeparam name="TKey">类型</typeparam>
    public class EntityBaseNoDeleted<TKey> : EntityBase<TKey> where TKey : struct
    {
        [NotMapped]
        public override int Deleted { get => base.Deleted; set => base.Deleted = value; }
    }

    /// <summary>
    /// 数据模型
    /// </summary>
    /// <typeparam name="TKey">主键类型</typeparam>
    public class EntityBase<TKey> : IEntity where TKey : struct
    {
        [Key]
        public TKey Id { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public virtual DateTime CreatedTime { get; set; } = DateTime.Now;
        /// <summary>
        /// 修改时间
        /// </summary>
        public virtual DateTime ModifiedTime { get; set; } = DateTime.Now;
        /// <summary>
        /// 操作人名称
        /// </summary>
        public virtual string OperatorName { get; set; }
        /// <summary>
        /// 软删除
        /// </summary>
        [DefaultValue(0)]
        public virtual int Deleted { get; set; }
    }
}
