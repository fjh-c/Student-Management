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
using Student.Core.API.Code.Attributes;
using Student.Core.API.Code.Core;
using Student.Core.API.Config;
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
        [OperationId("获取学生信息")]
        [Parameters(name = "id", param = "学生ID")]
        [ResponseCache(Duration = 0)]
        [HttpGet("{id}")]
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
        [Parameters(name = "pageIndex", param = "索引页")]
        [Parameters(name = "pageSize", param = "单页条数")]
        [Parameters(name = "search", param = "检索条件")]
        [ResponseCache(Duration = 0)]
        [HttpGet("{pageIndex}/{pageSize}/{search?}")]
        public Task<IResultModel> QueryPagedList([Required]int pageIndex, int pageSize, string search)
        {
            _logger.LogDebug($"获取学生分页列表");
            return StudentInfoService.Value.QueryPagedList(pageIndex, pageSize, search);
        }

        [Description("添加学生信息，成功后返回当前学生信息，上传图片转Base64存Photos属性中")]
        [OperationId("添加学生信息，通过模型添加")]
        [HttpPost("InsertModel")]
        public async Task<IResultModel> InsertModel([FromBody] StudentInfoDTO model)
        {
            //保存上传图片
            if (model.Photos.NotNull())
            {
                var bytes = Convert.FromBase64String(model.Photos);
                var file = new MemoryStream(bytes);
                IFormFile formFile = new FormFile(file, 0, file.Length, "", model.IdentityCard);
                var photopath = await SystemConfig.UploadSave(formFile, SystemConfig.photosPath(), true, SystemConfig.FileExt.jpg);
                model.Photos = photopath;
            }
            return await StudentInfoService.Value.Insert(model);
        }

        [Description("添加学生信息，成功后返回当前学生信息")]
        [OperationId("添加学生信息，原表单数据提交")]
        [HttpPost]
        public async Task<IResultModel> Insert([FromForm]StudentInfoDTO model)
        {
            _logger.LogDebug("添加学生信息");
            //保存上传图片
            if (model.PhotosFile != null)
            {
                var photopath = await SystemConfig.UploadSave(model.PhotosFile, SystemConfig.photosPath(), true, SystemConfig.FileExt.jpg);
                model.Photos = photopath;
            }
            else if (Request.Form.Files.Count > 0) //WebApiClient上传文件模型中接收不到，只能单独IFormFile参数或Request.Form中获取
            {
                var file = Request.Form.Files.FirstOrDefault();
                var photopath = await SystemConfig.UploadSave(file, SystemConfig.photosPath(), true, SystemConfig.FileExt.jpg);
                model.Photos = photopath;
            }
            return await StudentInfoService.Value.Insert(model);
        }

        [Description("修改学生信息，成功后返回当前学生信息")]
        [OperationId("修改学生信息")]
        [HttpPut]
        public async Task<IResultModel> Update([FromForm]StudentInfoDTO model)
        {
            _logger.LogDebug("修改学生信息");
            //保存上传图片
            if (Request.Form.Files.Count > 0)
            {
                var file = Request.Form.Files.FirstOrDefault();
                var photopath = await SystemConfig.UploadSave(file, SystemConfig.photosPath(), true, SystemConfig.FileExt.jpg);
                model.Photos = photopath;
            }
            return await StudentInfoService.Value.Update(model);
        }

        [Description("通过指定学生ID删除当前学生信息")]
        [OperationId("删除学生信息")]
        [Parameters(name = "id", param = "学生ID")]
        [HttpDelete("{id}")]
        public Task<IResultModel> Delete([Required]long id)
        {
            _logger.LogDebug("删除学生信息");
            return StudentInfoService.Value.Delete(id);
        }

        [Description("传入1个或多个学生ID数组[]，批量删除学生信息")]
        [OperationId("批量删除学生信息")]
        [HttpDelete]
        public async Task<IResultModel> DeleteAll([FromBody]IList<long> ids)
        {
            _logger.LogDebug("批量删除学生信息");
            await StudentInfoService.Value.Delete(ids);
            return ResultModel.Failed();
        }
    }
}
