using StudentManageSystem.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiClient;
using WebApiClient.Attributes;

namespace StudentManageSystem.Code.WebApi
{
    [JsonReturn]
    public interface IWebApiHelper : IHttpApi
    {
        [HttpGet("api/StudentInfo/QueryList")]
        ITask<ResultModel<IList<StudentInfoViewModel>>> GetStudentInfoListAsync();
    }

    /// <summary>
    /// 接口返回模型
    /// </summary>
    public class ResultModel<T>
    {
        public bool Success { get; set; }

        public string Msg { get; set; }

        public int Code { get; set; }

        public T Data { get; set; }
    }
}
