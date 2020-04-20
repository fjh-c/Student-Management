using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManageSystem.Models
{
    public class LoginViewModel
    {
        [Required]
        public string userid { get; set; }
        [Required]
        public string password { get; set; }
        [Required]
        public string code { get; set; }
    }
}
