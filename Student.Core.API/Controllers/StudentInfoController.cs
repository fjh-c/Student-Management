using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Student.DTO;
using Student.IServices;
using yrjw.ORM.Chimp.Result;

namespace Student.Core.API.Controllers
{
    [Description("学生信息")]
    public class StudentInfoController : ControllerAbstract
    {
        private readonly ILogger<StudentInfoController> _logger;

        public Lazy<IStudentInfoService> StudentInfoService { get; set; }

        public StudentInfoController(ILogger<StudentInfoController> logger)
        {
            _logger = logger;
        }

        [Description("默认获取学生列表")]
        [HttpGet]
        public Task<IResultModel> QueryList()
        {
            return StudentInfoService.Value.QueryList();
        }
    }
}
