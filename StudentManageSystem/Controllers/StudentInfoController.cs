using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
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
                return RedirectToAction("Message", "Home", new { Status = "Success", Redirect = "/StudentInfo/Add" });
            }
            ModelState.AddModelError("error", "添加失败！");
            await GetDepartList();
            return View("Add", model);
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
