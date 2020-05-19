using Student.DTO;
using System.Collections.Generic;
using WebApiClient;
using WebApiClient.Attributes;
using WebApiClient.Parameterables;
using yrjw.ORM.Chimp;
using yrjw.ORM.Chimp.Result;

namespace StudentManageSystem.Code.WebApi
{
    [JsonReturn]
    public partial interface IWebApiHelper : IHttpApi
    {
        /// <summary>
        /// 根据ID获取指定学生信息
        /// </summary>
        /// <returns></returns>
        [HttpGet("api/StudentInfo/{id}")]
        ITask<ResultModel<StudentInfoDTO>> GetStudentInfoAsync(long id);
        /// <summary>
        /// 获取学生分页列表
        /// </summary>
        /// <returns></returns>
        [HttpGet("api/StudentInfo/{pageIndex}/{pageSize}/{search}")]
        ITask<ResultModel<PagedList<StudentInfoDTO>>> GetStudentInfoPagedListAsync(int pageIndex, int pageSize, string search);
        /// <summary>
        /// 添加学生信息
        /// </summary>
        /// <returns></returns>
        [HttpPost("api/StudentInfo/Insert")]
        ITask<ResultModel<StudentInfoDTO>> PostStudentInfoInsertAsync([MulitpartContent]StudentInfoDTO model, MulitpartFile file);
        /// <summary>
        /// 修改学生信息
        /// </summary>
        /// <returns></returns>
        [HttpPut("api/StudentInfo/Update")]
        ITask<ResultModel<StudentInfoDTO>> PutStudentInfoUpdateAsync([MulitpartContent]StudentInfoDTO model, MulitpartFile file);

        /// <summary>
        /// 删除学生信息
        /// </summary>
        /// <returns></returns>
        [HttpDelete("api/StudentInfo/Delete/{id}")]
        ITask<ResultModel<string>> DeleteStudentInfoAsync(long id);

        /// <summary>
        /// 批量删除学生信息
        /// </summary>
        /// <returns></returns>
        [HttpDelete("api/StudentInfo/DeleteAll")]
        ITask<ResultModel<string>> DeleteAllStudentInfoAsync([JsonContent]IList<long> ids);


    }

    public partial interface IWebApiHelper : IHttpApi
    {
        /// <summary>
        /// 根据ID获取指定部门
        /// </summary>
        /// <returns></returns>
        [HttpGet("api/Depart/{id}")]
        ITask<ResultModel<DepartDTO>> GetDepartAsync(int id);
        /// <summary>
        /// 获取全部部门列表
        /// </summary>
        /// <returns></returns>
        [HttpGet("api/Depart")]
        ITask<ResultModel<List<DepartDTO>>> GetDepartListAsync();
    }
}
