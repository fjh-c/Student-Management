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
    public class AccountController : Controller
    {
        private readonly ILogger<AccountController> _logger;
        public readonly IAccountApi _accountApi;

        public AccountController(ILogger<AccountController> logger, IAccountApi accountApi)
        {
            _logger = logger;
            _accountApi = accountApi;
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
        public async Task<IActionResult> EditAsync(Guid id)
        {
            var result = await _accountApi.GetAccountAsync(id);
            if (result.Success == false)
            {
                return View();
            }
            return View(result.Data);
        }

        //表单提交，保存账户信息，id=0 添加，id>0 修改
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SaveAsync(AccountDTO model)
        {
            if (ModelState.IsValid)
            {
                IResultModel result;
                if (model.Id == Guid.Empty)
                {
                    result = await _accountApi.PostAccountInsertAsync(model);
                }
                else
                {
                    result = await _accountApi.PutAccountUpdateAsync(model);
                }
                if (result.Success)
                {
                    var _msg = model.Id == Guid.Empty ? "添加成功！" : "修改成功！";
                    return RedirectToAction("ShowMsg", "Home", new { msg = _msg });
                }
                else
                {
                    switch (result.Code)
                    {
                        case (int)EnumErrorCode.UserName:
                            ModelState.AddModelError("UserName", result.Msg);
                            break;
                        default:
                            ModelState.AddModelError("error", result.Msg);
                            break;
                    }
                }
            }
            if (model.Id == Guid.Empty)
            {
                return View("Create", model);
            }
            return View("Edit", model);
        }

        //删除操作 ajax请求返回json
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            var result = await _accountApi.DeleteAccountAsync(id);
            return Json(new Result() { success = result.Success, msg = result.Msg });
        }

        //Layui数据表格异步获取展示列表数据
        [ResponseCache(Duration = 0)]
        [HttpGet]
        public async Task<IActionResult> GetQueryListAsync()
        {
            var result = await _accountApi.GetAccountListAsync();
            if (result.Success)
            {
                return Json(new Table() { data = result.Data, count = result.Data.Count });
            }
            return Json(new Table() { data = null, count = 0 });
        }
    }
}
