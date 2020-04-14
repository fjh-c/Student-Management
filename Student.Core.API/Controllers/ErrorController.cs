using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Student.Core.API.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    //public class ErrorController : Controller
    //{
    //    [Route("Error/{statusCode}")]
    //    public IActionResult HttpStatusCodeHandler(int statusCode)
    //    {
    //        var statusCodeResult = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
    //        var ex = statusCodeResult?.Error;
    //        switch (statusCode)
    //        {
    //            case 404:
    //                ViewBag.ErrorMessage = "抱歉，您访问的地址不存在！";
    //                break;
    //        }
    //        return View("NotFound");
    //    }

    //    [Route("Error")]
    //    public IActionResult Error()
    //    {
    //        var exceptionHandlerPathFeature = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
    //        var ex = exceptionHandlerPathFeature.Error.Message;
    //        return View("Error");
    //    }
    //}
}