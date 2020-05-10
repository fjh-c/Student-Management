using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Student.Core.API.Code.Core;
using Student.DTO;
using Student.IServices;
using yrjw.ORM.Chimp.Result;

namespace Student.Core.API.Controllers
{
    [Description("学生信息")]
    public class StudentInfoController : ControllerAbstract
    {
        public StudentInfoController(ILogger<ControllerAbstract> logger) : base(logger)
        {
        }

        public Lazy<IStudentInfoService> StudentInfoService { get; set; }


        [Description("根据ID获取指定学生信息")]
        [ResponseCache(Duration = 0)]
        [HttpGet]
        public Task<IResultModel> Query([Required]long id)
        {
            _logger.LogDebug($"根据ID获取指定学生信息{id}");
            return StudentInfoService.Value.Query(id);
        }

        [Description("获取全部学生列表")]
        [ResponseCache(Duration = 0)]
        [HttpGet]
        public Task<IResultModel> QueryList()
        {
            _logger.LogDebug($"获取全部学生列表");
            return StudentInfoService.Value.QueryList();
        }

        [Description("获取学生分页列表")]
        [ResponseCache(Duration = 0)]
        [HttpGet]
        public Task<IResultModel> QueryPagedList([Required]int pageIndex, int pageSize, string search)
        {
            _logger.LogDebug($"获取学生分页列表");
            return StudentInfoService.Value.QueryPagedList(pageIndex, pageSize, search);
        }

        [Description("添加学生信息")]
        [HttpPost]
        public Task<IResultModel> Insert([FromForm]StudentInfoDTO model, IFormFile file)
        {
            _logger.LogDebug("添加学生信息");
            model.Photos = SystemConfig.photosPath();
            model.PhotosFile = file;
            return StudentInfoService.Value.Insert(model);
        }

        [Description("修改学生信息")]
        [HttpPut]
        public Task<IResultModel> Update(StudentInfoDTO model)
        {
            _logger.LogDebug("修改学生信息");
            return StudentInfoService.Value.Update(model);
        }

        [Description("删除学生信息")]
        [HttpDelete]
        public Task<IResultModel> Delete([Required]long id)
        {
            _logger.LogDebug("删除学生信息");
            return StudentInfoService.Value.Delete(id);
        }

        [Description("批量删除学生信息")]
        [HttpDelete]
        public async Task<IResultModel> DeleteAll([FromBody]IList<long> ids)
        {
            _logger.LogDebug("批量删除学生信息");
            foreach (var id in ids)
            {
                await StudentInfoService.Value.Delete(id, false);
            }
            if (StudentInfoService.Value.UnitOfWork.SaveChanges() > 0)
            {
                return ResultModel.Success();
            }
            return ResultModel.Failed();
        }
    }
}
