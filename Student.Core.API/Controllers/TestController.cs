using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Student.Core.API.Code.WebApi;
using Student.DTO;
using Student.IServices;
using yrjw.ORM.Chimp.Result;

namespace Student.Core.API.Controllers
{
    [Description("测试")]
    public class TestController : ControllerAbstract
    {
        private readonly IWebApiHelper _webApi;

        public TestController(ILogger<ControllerAbstract> logger, IWebApiHelper webApi) : base(logger)
        {
            _webApi = webApi;
        }

        [Description("获取学生列表,模拟调用三方接口获取数据")]
        [ResponseCache(Duration = 0)]
        [HttpGet]
        public async Task<IResultModel> QueryList()
        {
            var result = await _webApi.GetStudentInfoListAsync();
            return result;
        }
    }
}
