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
        /// <summary>
        /// 获取全部学生列表
        /// </summary>
        /// <returns></returns>
        [HttpGet("api/StudentInfo/QueryList")]
        ITask<ResultModel<List<StudentInfoDTO>>> GetStudentInfoListAsync();
        /// <summary>
        /// 获取学生分页列表
        /// </summary>
        /// <returns></returns>
        [HttpGet("api/StudentInfo/QueryPagedList")]
        ITask<ResultModel<PagedList<StudentInfoDTO>>> GetStudentInfoPagedListAsync(int pageIndex, int pageSize, string search);
        /// <summary>
        /// 获取全部部门列表
        /// </summary>
        /// <returns></returns>
        [HttpGet("api/Depart/QueryList")]
        ITask<ResultModel<List<DepartDTO>>> GetDepartListAsync();
    }
}
