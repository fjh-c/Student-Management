using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManageSystem.ViewModels
{
    public class Table
    {
        public int code { get; set; } = 0;
        public string msg { get; set; }
        public int count { get; set; }
        public dynamic data { get; set; }
    }

    public class tree
    {
        public int id { get; set; }
        public string label { get; set; }
        public bool isLeaf { get; set; }
        public List<tree> children { get; set; }

    }
}
