﻿using Student.DTO;
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
        ITask<ResultModel<DepartDTO>> GetDepartAsync(int id);
        /// <summary>
        /// 获取全部部门列表
        /// </summary>
        /// <returns></returns>
        [HttpGet("api/Depart")]
        ITask<ResultModel<List<DepartDTO>>> GetDepartListAsync();
    }
}