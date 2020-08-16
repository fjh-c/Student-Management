using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Student.DTO;
using StudentManageSystem.HttpApis;
using StudentManageSystem.ViewModels;
using yrjw.CommonToolsCore.Helper;
using yrjw.ORM.Chimp.Result;

namespace StudentManageSystem.Controllers
{
    public class ConfigController : Controller
    {
        private readonly ILogger<ConfigController> _logger;
        public readonly IConfigApi _configApi;

        public ConfigController(ILogger<ConfigController> logger, IConfigApi departApi)
        {
            _logger = logger;
            _configApi = departApi;
        }

        [HttpGet]
        [Authorize]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SaveAsync(ConfigDTO model)
        {
            if (ModelState.IsValid)
            {
                IResultModel<ConfigDTO> result = await _configApi.UpdateAsync(model);
                if (result.Success)
                {
                    return RedirectToAction("ShowMsg", "Home", new { msg = "保存成功！", json = JsonHelper.SerializeJSON(result.Data) });
                }
                else
                {
                    if (result.Errors.Count > 0)
                    {
                        ModelState.AddModelError(result.Errors[0].Id, result.Errors[0].Msg);
                    }
                    else
                    {
                        ModelState.AddModelError("error", result.Msg);
                    }
                }
            }
            return View("Edit", model);
        }
    }
}
