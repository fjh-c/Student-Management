﻿using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Student.Model
{
    [NotMapped]
    public partial class StudentInfo
    {
        /// <summary>
        /// 性别
        /// </summary>
        public string GenderName => Gender.ToDescription();
    }
}
