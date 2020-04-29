using Student.DTO;
using System.Collections.Generic;
using WebApiClient;
using WebApiClient.Attributes;
using yrjw.ORM.Chimp;
using yrjw.ORM.Chimp.Result;

namespace StudentManageSystem.Code.WebApi
{
    [JsonReturn]
    public interface IWebApiHelper : IHttpApi
    {
        [HttpGet("api/StudentInfo/QueryList")]
        ITask<ResultModel<List<StudentInfoDTO>>> GetStudentInfoListAsync();
        [HttpGet("api/StudentInfo/QueryPagedList")]
        ITask<ResultModel<PagedList<StudentInfoDTO>>> GetStudentInfoPagedListAsync(int pageIndex, int pageSize, string search);
    }
}
