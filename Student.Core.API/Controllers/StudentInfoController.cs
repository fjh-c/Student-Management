using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Student.IServices;

namespace Student.Core.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentInfoController : Controller
    {
        private readonly ILogger<StudentInfoController> _logger;

        public Lazy<IStudentInfoService> StudentInfoService { get; set; }

        public StudentInfoController(ILogger<StudentInfoController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<object> Get()
        {
            var entity = StudentInfoService.Value.RepositoryStudentInfo.TableNoTracking.ToList();
            return entity;
        }
    }
}
