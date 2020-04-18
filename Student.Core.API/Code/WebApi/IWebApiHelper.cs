﻿using Student.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiClient;
using WebApiClient.Attributes;
using yrjw.ORM.Chimp.Result;

namespace Student.Core.API.Code.WebApi
{
    [JsonReturn]
    public interface IWebApiHelper: IHttpApi
    {
        [HttpGet("api/StudentInfo/QueryList")]
        ITask<StudentInfoListResultModel> GetStudentInfoListAsync();
    }

    /// <summary>
    /// 接口返回模型
    /// </summary>
    public class StudentInfoListResultModel
    {
        public bool Success { get; set; }

        public string Msg { get; set; }

        public int Code { get; set; }

        public List<StudentInfoDTO> Data { get; set; }
    }
}
