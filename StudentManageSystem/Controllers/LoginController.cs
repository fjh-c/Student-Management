using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StudentManageSystem.HttpApis;
using StudentManageSystem.ViewModels;
using yrjw.CommonToolsCore.Helper;

namespace StudentManageSystem.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILogger<LoginController> _logger;
        public readonly IAuthApi _authApi;

        public LoginController(ILogger<LoginController> logger, IAuthApi authApi)
        {
            _logger = logger;
            _authApi = authApi;
        }

        public async Task<IActionResult> IndexAsync()
        {
            var userid = TempData["userid"];
            if (userid != null)
                return View(new LoginViewModel() { userid = userid.ToString() });
            return View(new LoginViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(LoginViewModel model)
        {
            int n = -1;
            if (ModelState.IsValid)
            {
                var code = TempData["ValidateCode"];
                if (code == null || code.ToString() != model.code)
                {
                    n = -2;
                }
                else
                {
                    n = await LogCheckIn(model);
                }
            }

            switch (n)
            {
                case 0:
                    //SaveUserCookie(model); //登录成功

                    // 写入日志
                    //LogHelper.WriteDBLog(model.userid, 0, "登录成功");
                    break;
                case -1:
                    ModelState.AddModelError("error", "用户名或密码错误!");
                    break;
                case -2:
                    ModelState.AddModelError("error", "验证码错误!");
                    break;
                case -3:
                    ModelState.AddModelError("error", "账号不存在!");
                    break;
                case -4:
                    ModelState.AddModelError("error", "手机号尚未绑定!");
                    break;
                case -5:
                    ModelState.AddModelError("error", "身份证号尚未绑定!");
                    break;
                case -6:
                    ModelState.AddModelError("error", "请使用教师或家长帐号登陆!");
                    break;
                default:
                    break;
            }
            return View(model);
        }

        private async Task<int> LogCheckIn(LoginViewModel model)
        {
            return 0;
        }

        public async Task<IActionResult> GetValidataCodeAsync()
        {
            var result = await _authApi.GetVerifyCode(4);
            if (result.Success)
            {
                var code = result.Data.Id;
                TempData["ValidateCode"] = code;

                var imgValidateCode = Convert.FromBase64String(result.Data.Code.Replace("data:image/png;base64,",""));
                return File(imgValidateCode, "image/jpeg");
            }
            return File(ValidateCodeHelper.CreateValidateGraphic(""), "image/jpeg");
        }

    }
}