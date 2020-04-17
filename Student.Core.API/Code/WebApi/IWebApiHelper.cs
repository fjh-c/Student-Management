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
        ITask<ResultModel<DTO.StudentInfoDTO>> GetStudentInfoListAsync();
    }
}
