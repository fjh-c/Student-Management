﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;
using yrjw.ORM.Chimp;

namespace Student.Model
{
    /// <summary>
    /// 数据模型标准父类
    /// </summary>
    /// <typeparam name="T">类型</typeparam>
    public class EntityBase: EntityBase<int> 
    {

    }

    /// <summary>
    /// 数据模型标准父类
    /// </summary>
    /// <typeparam name="T">类型</typeparam>
    public class EntityBase<T>: IEntity where T : struct
    {
        [Key]
        public T Id { get; set; }
        /// <summary>
        /// 激活状态
        /// </summary>
        [DefaultValue(0)]
        public virtual int Status { get; set; }
    }
}
