using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using Microsoft.VisualBasic;
using Student.DTO;
using StudentManageSystem.Code.WebApi;
using StudentManageSystem.ViewModels;
using WebApiClient.Parameterables;
using yrjw.ORM.Chimp.Result;

namespace StudentManageSystem.Controllers
{
    public class StudentInfoController : Controller
    {
        private readonly ILogger<StudentInfoController> _logger;
        public readonly IWebApiHelper _webApi;

        public StudentInfoController(ILogger<StudentInfoController> logger, IWebApiHelper webApi)
        {
            _logger = logger;
            _webApi = webApi;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> CreateAsync()
        {
            await GetDepartList();
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> EditAsync(long? id)
        {
            var result = await _webApi.GetStudentInfoAsync(id.Value);
            if (result.Success == false)
            {
                return View();  //建议跳转到指定错误页面
            }
            await GetDepartList();
            return View(result.Data);
        }

        private async Task GetDepartList()
        {
            var result = await _webApi.GetDepartListAsync();
            var list = result.Data.Select(p => new SelectListItem(p.DepartName, p.Id.ToString(), false, p.GradeId == null));
            ViewBag.DepartClassesList = list;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SaveAsync(StudentInfoDTO model)
        {
            if (ModelState.IsValid)
            {
                IResultModel result;
                MulitpartFile file = null;
                if (model.PhotosFile != null && model.PhotosFile.Length > 0)
                {
                    file = new MulitpartFile(model.PhotosFile.OpenReadStream(), model.PhotosFile.FileName);
                }
                if (model.Id == 0)
                {
                    result = await _webApi.PostStudentInfoInsertAsync(model, file);
                }
                else
                {
                    result = await _webApi.PutStudentInfoUpdateAsync(model, file);
                }
                if (result.Success)
                {
                    var _msg = model.Id == 0 ? "添加成功！" : "修改成功！";
                    return RedirectToAction("ShowMsg", "Home", new { msg = _msg });
                }
                else
                {
                    switch (result.Code)
                    {
                        case (int)EnumErrorCode.Departid:
                            ModelState.AddModelError("DepartId", result.Msg);
                            break;
                        case (int)EnumErrorCode.Phone:
                            ModelState.AddModelError("Phone", result.Msg);
                            break;
                        case (int)EnumErrorCode.IdentityCard:
                            ModelState.AddModelError("IdentityCard", result.Msg);
                            break;
                        default:
                            ModelState.AddModelError("error", result.Msg);
                            break;
                    }
                }
            }
            await GetDepartList();
            if (model.Id == 0)
            {
                return View("Create", model);
            }
            return View("Edit", model);
        }

        

        public async Task<IActionResult> DetailsAsync(long? id)
        {
            var result = await _webApi.GetStudentInfoAsync(id.Value);
            if (result.Data.Photos.IsNull())
            {
                result.Data.Photos = "/images/upload-img.jpg";
            }
            else
            {
                result.Data.Photos = Code.ViewsHelper.GetStudentPhotosPath(result.Data.Photos);
            }
            
            if (result.Success == false)
            {
                return View();  //建议跳转到指定错误页面
            }
            return View(result.Data);
        }

        [ResponseCache(Duration = 0)]
        [HttpGet]
        public async Task<IActionResult> GetQueryPagedListAsync(int page, int limit, string search)
        {
            var result = await _webApi.GetStudentInfoPagedListAsync(page, limit, search);
            foreach (var item in result.Data.Item)
            {
                if (item.Photos.IsNull())
                {
                    item.Photos = "/images/upload-img.jpg";
                    continue;
                }
                item.Photos = Code.ViewsHelper.GetStudentPhotosPath(item.Photos);
            }
            if (result.Success)
            {
                return Json(new Table() { data = result.Data.Item, count = result.Data.Total });
            }
            return Json(new Table() { data = null, count = 0 });
        }
    }
}
