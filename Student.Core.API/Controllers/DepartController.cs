using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Student.Core.API.Code.Attributes;
using Student.DTO;
using Student.IServices;
using yrjw.ORM.Chimp.Result;

namespace Student.Core.API.Controllers
{
    [Description("部门信息")]
    public class DepartController : ControllerAbstract
    {
        public DepartController(ILogger<ControllerAbstract> logger) : base(logger)
        {
        }

        public Lazy<IDepartService> DepartService { get; set; }


        [Description("通过指定部门ID，返回该部门信息")]
        [OperationId("获取部门信息")]
        [Parameters(name="id", param = "部门ID")]
        [ResponseCache(Duration = 0)]
        [HttpGet("{id}")]
        public async Task<IResultModel> Query([Required]int id)
        {
            _logger.LogDebug($"根据ID获取指定部门{id}");
            return await DepartService.Value.GetByIdAsync(id);
        }

        [Description("获取全部部门列表")]
        [ResponseCache(Duration = 0)]
        [HttpGet]
        public async Task<IResultModel> GetAllList()
        {
            _logger.LogDebug($"获取全部部门列表");
            return await DepartService.Value.GetAllListAsync();
        }

        [Description("获取所有班级列表")]
        [ResponseCache(Duration = 0)]
        [HttpGet("GetClassesList")]
        public async Task<IResultModel> GetClassesList()
        {
            _logger.LogDebug($"获取所有班级列表");
            return await DepartService.Value.GetClassesListAsync();
        }

        [Description("获取部门分页列表")]
        [Parameters(name = "pageIndex", param = "索引页")]
        [Parameters(name = "pageSize", param = "单页条数")]
        [Parameters(name = "search", param = "检索条件")]
        [ResponseCache(Duration = 0)]
        [HttpGet("{pageIndex}/{pageSize}/{search?}")]
        public async Task<IResultModel> GetPagedList([Required]int pageIndex, int pageSize, string search)
        {
            _logger.LogDebug($"获取部门分页列表");
            return await DepartService.Value.QueryPagedListAsync(pageIndex, pageSize, search);
        }

        [Description("添加部门，成功后返回当前部门信息")]
        [OperationId("添加部门")]
        [HttpPost]
        public async Task<IResultModel> Add([FromBody]DepartDTO model)
        {
            _logger.LogDebug("添加部门");
            return await DepartService.Value.InsertAsync(model);
        }

        [Description("修改部门，成功后返回当前部门信息")]
        [OperationId("修改部门")]
        [HttpPut]
        public async Task<IResultModel> Update([FromBody]DepartDTO model)
        {
            _logger.LogDebug("修改部门");
            return await DepartService.Value.UpdateAsync(model);
        }

        [Description("通过指定部门ID删除当前部门信息")]
        [OperationId("删除部门")]
        [Parameters(name = "id", param = "部门ID")]
        [HttpDelete("{id}")]
        public async Task<IResultModel> Delete([Required]int id)
        {
            _logger.LogDebug("删除部门");
            return await DepartService.Value.DeleteAsync(id);
        }

        [Description("传入1个或多个部门ID数组[]，批量删除部门信息")]
        [OperationId("批量删除部门")]
        [HttpDelete]
        public async Task<IResultModel> DeleteAll([FromBody]IList<int> ids)
        {
            _logger.LogDebug("批量删除部门");
            return await DepartService.Value.DeleteAsync(ids);
        }
    }
}
