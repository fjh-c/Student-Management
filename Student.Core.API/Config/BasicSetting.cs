using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using yrjw.ORM.Chimp;

namespace Student.Core.API.Config
{
    public class BasicSetting
    {
        public DbType DbType { get; set; }
        public string ConnectionString { get; set; }
        public static BasicSetting Setting { get; set; } = new BasicSetting();
    }
}
