using System;
using System.Collections.Generic;
using System.Text;

namespace Student.Model.Code
{
    public class InitializationData
    {
        public List<StudentInfo> StudentInfo { get; set; }
        public List<Nation> Nation { get; set; }

        public static InitializationData Initialization { get; set; } = new InitializationData();
    }
}
