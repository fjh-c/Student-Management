using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StudentManageSystem.ViewModels;

namespace StudentManageSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        public IActionResult MainPC()
        {
            return View();
        }

        /// <summary>
        /// 弹窗子窗口，保存后刷新父级页面数据表格
        /// </summary>
        /// <param name="msg">弹窗提示信息</param>
        /// <param name="json">不为空时，只刷新本地数据</param>
        /// <returns></returns>
        public IActionResult ShowMsg(string msg = "保存成功！", string json = "")
        {
            ViewBag.Msg = msg;
            ViewBag.Data = json;
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
