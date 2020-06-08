using Student.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiClient;
using WebApiClient.Attributes;
using yrjw.ORM.Chimp.Result;

namespace StudentManageSystem.HttpApis
{
    [JsonReturn]
    public interface IDepartApi : IHttpApi
    {
        /// <summary>
        /// 根据ID获取指定部门
        /// </summary>
        /// <returns></returns>
        [HttpGet("api/Depart/{id}")]
        ITask<ResultModel<DepartDTO>> QueryAsync(int id);
        /// <summary>
        /// 获取全部部门列表
        /// </summary>
        /// <returns></returns>
        [HttpGet("api/Depart")]
        ITask<ResultModel<List<DepartDTO>>> GetListAllAsync();
        /// <summary>
        /// 获取所有班级列表
        /// </summary>
        /// <returns></returns>
        [HttpGet("api/Depart/GetClassesList")]
        ITask<ResultModel<List<DepartDTO>>> GetClassesListAsync();
    }
}
