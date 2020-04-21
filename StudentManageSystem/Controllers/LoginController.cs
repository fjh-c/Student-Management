using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StudentManageSystem.Models;
using yrjw.CommonToolsCore.Helper;

namespace StudentManageSystem.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
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

        public IActionResult GetValidataCode()
        {
            var code = ValidateCodeHelper.CreateRandomNums(4);
            TempData["ValidateCode"] = code;
            return File(ValidateCodeHelper.CreateValidateGraphic(code), "image/jpeg");
        }

    }
}