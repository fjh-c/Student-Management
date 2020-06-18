using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManageSystem
{
    public class AppSetting
    {
        /// <summary>
        /// MVC网站访问IP端口
        /// </summary>
        public string Urls { get; set; }
        /// <summary>
        /// WebApi访问地址
        /// </summary>
        public string ApiUrl { get; set; }

        public static AppSetting Setting { get; set; } = new AppSetting();
    }
}
