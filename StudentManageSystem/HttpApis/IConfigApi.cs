using Auth.Jwt;
using StudentManageSystem.Code;
using WebApiClient;
using WebApiClient.Attributes;
using yrjw.ORM.Chimp.Result;

namespace StudentManageSystem.HttpApis
{
    [TokenFilter]
    [JsonReturn]
    public interface IConfigApi : IHttpApi
    {
        /// <summary>
        /// 获取权限配置信息
        /// </summary>
        /// <returns></returns>
        [HttpGet("api/Config/Auth")]
        ITask<ResultModel<AuthConfigData>> QueryAsync();

    }
}
