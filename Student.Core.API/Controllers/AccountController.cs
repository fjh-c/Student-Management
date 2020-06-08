using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Logging;
using Student.Core.API.Code.Attributes;
using Student.DTO;
using Student.IServices;
using yrjw.ORM.Chimp.Result;

namespace Student.Core.API.Controllers
{
    [Description("账户信息")]
    public class AccountController : ControllerAbstract
    {
        public AccountController(ILogger<ControllerAbstract> logger) : base(logger)
        {
        }

        public Lazy<IAccountService> AccountService { get; set; }


        [Description("通过指定账户ID，返回该账户信息")]
        [OperationId("获取账户信息")]
        [Parameters(name="id", param = "账户ID")]
        [ResponseCache(Duration = 0)]
        [HttpGet("{id}")]
        public async Task<IResultModel> Query([BindRequired]Guid id)
        {
            _logger.LogDebug($"操作：根据ID获取指定账户{id}");
            return await AccountService.Value.GetByIdAsync(id);
        }

        [Description("获取全部账户列表")]
        [ResponseCache(Duration = 0)]
        [HttpGet]
        public async Task<IResultModel> GetAllList()
        {
            _logger.LogDebug("操作：获取全部账户列表");
            return await AccountService.Value.GetAllListAsync();
        }

        [Description("添加账户，成功后返回当前账户信息")]
        [OperationId("添加账户")]
        [HttpPost]
        public async Task<IResultModel> Add([FromBody]AccountDTO model)
        {
            _logger.LogDebug($"操作：添加账户{model.UserName}");
            return await AccountService.Value.InsertAsync(model);
        }

        [Description("修改账户，成功后返回当前账户信息")]
        [OperationId("修改账户")]
        [HttpPut]
        public async Task<IResultModel> Update([FromBody]AccountDTO model)
        {
            _logger.LogDebug($"操作：修改账户{model.Id.ToString()}");
            return await AccountService.Value.UpdateAsync(model);
        }

        [Description("通过指定账户ID删除当前账户信息")]
        [OperationId("删除账户")]
        [Parameters(name = "id", param = "账户ID")]
        [HttpDelete("{id}")]
        public async Task<IResultModel> Delete([BindRequired]Guid id)
        {
            _logger.LogDebug($"操作：删除账户{id}");
            return await AccountService.Value.DeleteAsync(id);
        }

        [Description("修改账户密码信息")]
        [OperationId("修改密码")]
        [HttpPut("UpdatePassword")]
        public async Task<IResultModel> UpdatePassword([FromBody]UpdatePasswordDTO model)
        {
            _logger.LogDebug($"操作：修改密码{model.AccountId}");
            return await AccountService.Value.UpdatePassword(model);
        }
    }
}
