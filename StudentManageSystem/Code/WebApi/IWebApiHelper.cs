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
        /// 根据ID获取指定学生信息
        /// </summary>
        /// <returns></returns>
        [HttpGet("api/StudentInfo/Query")]
        ITask<ResultModel<StudentInfoDTO>> GetStudentInfoAsync(long id);
        /// <summary>
        /// 获取学生分页列表
        /// </summary>
        /// <returns></returns>
        [HttpGet("api/StudentInfo/QueryPagedList")]
        ITask<ResultModel<PagedList<StudentInfoDTO>>> GetStudentInfoPagedListAsync(int pageIndex, int pageSize, string search);
        /// <summary>
        /// 添加学生信息
        /// </summary>
        /// <returns></returns>
        [HttpPost("api/StudentInfo/Insert")]
        ITask<ResultModel<StudentInfoDTO>> PostStudentInfoInsertAsync([JsonContent]StudentInfoDTO model);
        /// <summary>
        /// 修改学生信息
        /// </summary>
        /// <returns></returns>
        [HttpPut("api/StudentInfo/Update")]
        ITask<ResultModel<StudentInfoDTO>> PutStudentInfoUpdateAsync([JsonContent]StudentInfoDTO model);

        /// <summary>
        /// 根据ID获取指定部门
        /// </summary>
        /// <returns></returns>
        [HttpGet("api/Depart/Query")]
        ITask<ResultModel<DepartDTO>> GetDepartAsync(int id);
        /// <summary>
        /// 获取全部部门列表
        /// </summary>
        /// <returns></returns>
        [HttpGet("api/Depart/QueryList")]
        ITask<ResultModel<List<DepartDTO>>> GetDepartListAsync();


    }
}
