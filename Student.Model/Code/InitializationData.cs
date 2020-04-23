﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Student.Model.Code
{
    public class InitializationData
    {
        public List<Admin> Admin { get; set; }
        public List<Depart> Depart { get; set; }
        public List<StudentInfo> StudentInfo { get; set; }

        public static InitializationData Initialization { get; set; } = new InitializationData();
    }
}
