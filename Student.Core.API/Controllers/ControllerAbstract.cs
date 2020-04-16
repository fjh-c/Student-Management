﻿using Microsoft.AspNetCore.Mvc;
using Student.Core.API.Code.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Student.Core.API.Controllers
{
    /// <summary>
    /// 控制器抽象类
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public abstract class ControllerAbstract : ControllerBase
    {
        /// <summary>
        /// 导出Excel
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="fileName"></param>
        /// <returns></returns>
        protected IActionResult ExportExcel(string filePath, string fileName)
        {
            if (fileName.IsNull())
            {
                fileName = DateTime.Now.ToString("yyyyMMddHHmmss");
            }
            return PhysicalFile(filePath, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", HttpUtility.UrlEncode(fileName), true);
        }
    }
}