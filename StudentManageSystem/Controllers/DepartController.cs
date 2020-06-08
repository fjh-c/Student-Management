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
using StudentManageSystem.HttpApis;
using StudentManageSystem.ViewModels;
using WebApiClient.Parameterables;
using yrjw.ORM.Chimp.Result;

namespace StudentManageSystem.Controllers
{
    public class DepartController : Controller
    {
        private readonly ILogger<DepartController> _logger;
        public readonly IDepartApi _departApi;

        public DepartController(ILogger<DepartController> logger, IDepartApi departApi)
        {
            _logger = logger;
            _departApi = departApi;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        //添加页面
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        //修改页面
        [HttpGet]
        public async Task<IActionResult> EditAsync(int id)
        {
            var result = await _departApi.QueryAsync(id);
            if (result.Success == false)
            {
                return View();
            }
            return View(result.Data);
        }

        //表单提交，保存部门信息，id=0 添加，id>0 修改
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SaveAsync(DepartDTO model)
        {
            if (ModelState.IsValid)
            {
                IResultModel result;
                if (model.Id == 0)
                {
                    result = await _departApi.AddAsync(model);
                }
                else
                {
                    result = await _departApi.UpdateAsync(model);
                }
                if (result.Success)
                {
                    var _msg = model.Id == 0 ? "添加成功！" : "修改成功！";
                    return RedirectToAction("ShowMsg", "Home", new { msg = _msg });
                }
                else
                {
                    if (result.FailedId.NotNull())
                    {
                        ModelState.AddModelError(result.FailedId, result.Msg);
                    }
                    else
                    {
                        ModelState.AddModelError("error", result.Msg);
                    }
                }
            }
            if (model.Id == 0)
            {
                return View("Create", model);
            }
            return View("Edit", model);
        }

        //删除操作 ajax请求返回json
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _departApi.DeleteAsync(id);
            return Json(new Result() { success = result.Success, msg = result.Msg });
        }

        //Layui数据表格异步获取展示列表数据
        [ResponseCache(Duration = 0)]
        [HttpGet]
        public async Task<IActionResult> GetQueryListAsync()
        {
            var result = await _departApi.GetListAllAsync();
            if (result.Success)
            {
                return Json(new Table() { data = result.Data, count = result.Data.Count });
            }
            return Json(new Table() { data = null, count = 0 });
        }
    }
}
