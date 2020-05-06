using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StudentManageSystem.Code.WebApi;
using StudentManageSystem.ViewModels;

namespace StudentManageSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IWebApiHelper _webApi;

        public HomeController(ILogger<HomeController> logger, IWebApiHelper webApi)
        {
            _logger = logger;
            _webApi = webApi;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult MainPC()
        {
            return View();
        }

        public IActionResult ShowMsg()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
