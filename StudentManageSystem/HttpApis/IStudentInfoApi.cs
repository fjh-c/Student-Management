using Student.DTO;
using StudentManageSystem.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiClient;
using WebApiClient.Attributes;
using WebApiClient.Parameterables;
using yrjw.ORM.Chimp;
using yrjw.ORM.Chimp.Result;

namespace StudentManageSystem.HttpApis
{
    [JsonReturn]
    public interface IStudentInfoApi : IHttpApi
    {
        /// <summary>
        /// 根据ID获取指定学生信息
        /// </summary>
        /// <returns></returns>
        [HttpGet("api/StudentInfo/{id}")]
        ITask<ResultModel<StudentInfoDTO>> QueryAsync(long id);
        /// <summary>
        /// 获取学生分页列表
        /// </summary>
        /// <returns></returns>
        [HttpGet("api/StudentInfo/{pageIndex}/{pageSize}/{search}")]
        ITask<ResultModel<PagedList<StudentInfoDTO>>> GetPagedListAsync(int pageIndex, int pageSize, string search);
        /// <summary>
        /// 添加学生信息，通过json提交
        /// </summary>
        /// <returns></returns>
        [HttpPost("api/StudentInfo/AddModel")]
        ITask<ResultModel<StudentInfoDTO>> AddAsync([JsonContent]StudentInfoDTO model);
        /// <summary>
        /// 添加学生信息
        /// </summary>
        /// <returns></returns>
        [HttpPost("api/StudentInfo")]
        ITask<ResultModel<StudentInfoDTO>> AddAsync([MulitpartContent]StudentInfoDTO model, MulitpartFile file);
        /// <summary>
        /// 修改学生信息
        /// </summary>
        /// <returns></returns>
        [HttpPut("api/StudentInfo")]
        ITask<ResultModel<StudentInfoDTO>> UpdateAsync([MulitpartContent]StudentInfoDTO model, MulitpartFile file);

        /// <summary>
        /// 删除学生信息
        /// </summary>
        /// <returns></returns>
        [HttpDelete("api/StudentInfo/{id}")]
        ITask<ResultModel<string>> DeleteAsync(long id);

        /// <summary>
        /// 批量删除学生信息
        /// </summary>
        /// <returns></returns>
        [HttpDelete("api/StudentInfo")]
        ITask<ResultModel<string>> DeleteAllAsync([JsonContent]IList<long> ids);
    }
}
