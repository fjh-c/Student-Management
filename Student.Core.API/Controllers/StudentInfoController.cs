using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Student.IServices;

namespace Student.Core.API.Controllers
{
    [Description("学生信息")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StudentInfoController : Controller
    {
        private readonly ILogger<StudentInfoController> _logger;

        public Lazy<IStudentInfoService> StudentInfoService { get; set; }

        public StudentInfoController(ILogger<StudentInfoController> logger)
        {
            _logger = logger;
        }

        [Description("默认获取学生列表")]
        [HttpGet]
        public IEnumerable<object> QueryList()
        {
            var entity = StudentInfoService.Value.RepositoryStudentInfo.TableNoTracking.ToList();
            return entity;
        }
    }
}
