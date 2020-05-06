using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using Microsoft.VisualBasic;
using Student.DTO;
using StudentManageSystem.Code.WebApi;
using StudentManageSystem.ViewModels;

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
        public async Task<IActionResult> AddAsync()
        {
            await GetDepartList();
            return View();
        }

        private async Task GetDepartList()
        {
            var result = await _webApi.GetDepartListAsync();
            var list = result.Data.Select(p => new SelectListItem(p.DepartName, p.Id.ToString(), false, p.GradeId == null));
            ViewBag.DepartClassesList = list;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddAsync(StudentInfoDTO model)
        {
            if (ModelState.IsValid)
            {
                var result = new yrjw.ORM.Chimp.Result.ResultModel<StudentInfoDTO>();
                if(model.Id == 0)
                {
                    result = await _webApi.PutStudentInfoInsertAsync(model);
                }
                else
                {
                    result = await _webApi.PutStudentInfoUpdateAsync(model);
                }
                if (result.Success)
                {
                    return RedirectToAction("ShowMsg", "Home", new { msg = result.Msg });
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
            return View("Add", model);
        }

        public async Task<IActionResult> EditAsync(long? id)
        {
            var result = await _webApi.GetStudentInfoAsync(id.Value);
            if (result.Success == false)
            {
                return View();  //建议跳转到指定错误页面
            }
            await GetDepartList();
            return View("Add", result.Data);
        }

        public async Task<IActionResult> DetailsAsync(long? id)
        {
            var result = await _webApi.GetStudentInfoAsync(id.Value);
            if(result.Success == false)
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
            if (result.Success)
            {
                return Json(new Table() { data = result.Data.Item, count = result.Data.Total });
            }
            return Json(new Table() { data = null, count = 0 });
        }
    }
}
