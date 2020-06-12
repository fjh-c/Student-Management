﻿using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using Student.Core.API.Code.Middleware;
using Student.Core.API.Config;

namespace Student.Core.API.Code.Attributes
{
    /// <summary>
    /// 模型验证结果格式化过滤器
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    public class ValidateResultFormatAttribute : ActionFilterAttribute
    {
        public override void OnResultExecuting(ResultExecutingContext context)
        {
            if (!context.ModelState.IsValid && BasicSetting.Setting.Validator == 1)
            {
                try
                {
                    var formatHandler = context.HttpContext.RequestServices.GetService<IValidateResultFormatHandler>();
                    formatHandler.Format(context);
                }
                catch
                {
                    context.Result = new StatusCodeResult(StatusCodes.Status500InternalServerError);
                }
            }
        }
    }
}
