using Auth.Jwt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManageSystem.ViewModels
{
    public class ConfigViewModel
    {
        public AuthConfigData AuthConfigData { get; set; } = new AuthConfigData();

        public string Title { get; set; }
    }
}
