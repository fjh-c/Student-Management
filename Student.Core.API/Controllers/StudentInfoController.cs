using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
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

        [Description("获取学生信息")]
        [ResponseCache(Duration = 0)]
        [HttpGet]
        public Task<IResultModel> Query([Required]long id)
        {
            _logger.LogDebug("获取学生信息");
            return StudentInfoService.Value.Query(id);
        }

        [Description("获取学生列表")]
        [ResponseCache(Duration = 0)]
        [HttpGet]
        public Task<IResultModel> QueryList()
        {
            return StudentInfoService.Value.QueryList();
        }
    }
}
