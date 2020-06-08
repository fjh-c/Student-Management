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
    public interface IAccountApi : IHttpApi
    {
        /// <summary>
        /// 根据ID获取指定账户信息
        /// </summary>
        /// <returns></returns>
        [HttpGet("api/Account/{id}")]
        ITask<ResultModel<AccountDTO>> GetAccountAsync(Guid id);

        /// <summary>
        /// 获取全部账户信息列表
        /// </summary>
        /// <returns></returns>
        [HttpGet("api/Account")]
        ITask<ResultModel<List<AccountDTO>>> GetAccountListAsync();

        /// <summary>
        /// 添加账户信息
        /// </summary>
        /// <returns></returns>
        [HttpPost("api/Account")]
        ITask<ResultModel<AccountDTO>> PostAccountInsertAsync([JsonContent]AccountDTO model);

        /// <summary>
        /// 修改账户信息
        /// </summary>
        /// <returns></returns>
        [HttpPut("api/Account")]
        ITask<ResultModel<AccountDTO>> PutAccountUpdateAsync([JsonContent]AccountDTO model);

        /// <summary>
        /// 删除账户信息
        /// </summary>
        /// <returns></returns>
        [HttpDelete("api/Account/{id}")]
        ITask<ResultModel<string>> DeleteAccountAsync(Guid id);

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <returns></returns>
        [HttpPut("api/Account/UpdatePassword")]
        ITask<ResultModel<string>> UpdatePasswordAsync(Guid id);
    }
}
