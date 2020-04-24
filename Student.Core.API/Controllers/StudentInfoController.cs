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

        [Description("根据ID获取指定学生信息")]
        [ResponseCache(Duration = 0)]
        [HttpGet]
        public Task<IResultModel> Query([Required]long id)
        {
            _logger.LogDebug($"根据ID获取指定学生信息{id}");
            return StudentInfoService.Value.Query(id);
        }

        [Description("获取全部学生列表")]
        [ResponseCache(Duration = 0)]
        [HttpGet]
        public Task<IResultModel> QueryList()
        {
            _logger.LogDebug($"获取全部学生列表");
            return StudentInfoService.Value.QueryList();
        }

        [Description("添加学生信息")]
        [ResponseCache(Duration = 0)]
        [HttpGet]
        public Task<IResultModel> Insert(StudentInfoInsert model)
        {
            _logger.LogDebug("添加学生信息");
            return StudentInfoService.Value.Insert(model);
        }
    }
}
