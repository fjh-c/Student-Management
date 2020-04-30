using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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


        [Description("根据ID获取指定部门")]
        [ResponseCache(Duration = 0)]
        [HttpGet]
        public Task<IResultModel> Query([Required]int id)
        {
            _logger.LogDebug($"根据ID获取指定部门{id}");
            return DepartService.Value.Query(id);
        }

        [Description("获取全部部门列表")]
        [ResponseCache(Duration = 0)]
        [HttpGet]
        public Task<IResultModel> QueryList()
        {
            _logger.LogDebug($"获取全部部门列表");
            return DepartService.Value.QueryList();
        }

        [Description("获取部门分页列表")]
        [ResponseCache(Duration = 0)]
        [HttpGet]
        public Task<IResultModel> QueryPagedList([Required]int pageIndex, int pageSize, string search)
        {
            _logger.LogDebug($"获取部门分页列表");
            return DepartService.Value.QueryPagedList(pageIndex, pageSize, search);
        }

        [Description("添加部门")]
        [HttpPost]
        public Task<IResultModel> Insert(DepartDTO model)
        {
            _logger.LogDebug("添加部门");
            return DepartService.Value.Insert(model);
        }

        [Description("修改部门")]
        [HttpPut]
        public Task<IResultModel> Update(DepartDTO model)
        {
            _logger.LogDebug("修改部门");
            return DepartService.Value.Update(model);
        }

        [Description("删除部门")]
        [HttpDelete]
        public Task<IResultModel> Delete([Required]int id)
        {
            _logger.LogDebug("删除部门");
            return DepartService.Value.Delete(id);
        }

        [Description("批量删除部门")]
        [HttpDelete]
        public async Task<IResultModel> DeleteAll([FromBody]IList<int> ids)
        {
            _logger.LogDebug("批量删除部门");
            foreach (var id in ids)
            {
                await DepartService.Value.Delete(id, false);
            }
            if (DepartService.Value.UnitOfWork.SaveChanges() > 0)
            {
                return ResultModel.Success();
            }
            return ResultModel.Failed();
        }
    }
}
