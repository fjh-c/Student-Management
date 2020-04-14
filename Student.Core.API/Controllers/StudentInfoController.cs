using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Student.IServices;

namespace Student.Core.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentInfoController : Controller
    {
        private readonly ILogger<StudentInfoController> _logger;

        public Lazy<IStudentInfoService> StudentInfoService { get; set; }

        public StudentInfoController(ILogger<StudentInfoController> logger)
        {
            _logger = logger;
        }
        // GET api/StudentInfo
        /// <summary>
        /// 默认获取学生列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<object> Get()
        {
            var entity = StudentInfoService.Value.RepositoryStudentInfo.TableNoTracking.ToList();
            return entity;
        }
    }
}
