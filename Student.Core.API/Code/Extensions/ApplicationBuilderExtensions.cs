﻿using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Student.Core.API.Code.Middleware;
using Student.Core.API.Config;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using yrjw.CommonToolsCore.Helper;
using yrjw.ORM.Chimp.Result;

namespace Microsoft.AspNetCore.Builder
{
    public static class ApplicationBuilderExtensions
    {
        /// <summary>
        /// 启用WebHost
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env">环境</param>
        /// <returns></returns>
        public static IApplicationBuilder UseWebHost(this IApplicationBuilder app, IWebHostEnvironment env)
        {
            //异常处理
            app.UseExceptionHandle();

            //设置默认文档
            var defaultFilesOptions = new DefaultFilesOptions();
            defaultFilesOptions.DefaultFileNames.Clear();
            defaultFilesOptions.DefaultFileNames.Add("index.html");
            app.UseDefaultFiles(defaultFilesOptions);

            //启用默认页
            app.UseDefaultPage();

            //启动文档页
            app.UseDocs();

            //CORS
            app.UseCors("Default");

            //路由
            app.UseRouting();

            //认证
            app.UseAuthentication();

            //授权
            app.UseAuthorization();

            //配置端点
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            //开启Swagger
            if (env.IsDevelopment())
            {
                app.UseCustomSwagger();
            }

            return app;
        }

        /// <summary>
        /// 启用默认页
        /// </summary>
        /// <param name="app"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseDefaultPage(this IApplicationBuilder app)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/app");
            if (Directory.Exists(path))
            {
                var options = new StaticFileOptions
                {
                    FileProvider = new PhysicalFileProvider(path),
                    RequestPath = new PathString("/app")
                };

                app.UseStaticFiles(options);

                var rewriteOptions = new RewriteOptions().AddRedirect("^$", "app");

                app.UseRewriter(rewriteOptions);
            }

            return app;
        }

        /// <summary>
        /// 启动文档页
        /// </summary>
        /// <param name="app"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseDocs(this IApplicationBuilder app)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/docs");
            if (Directory.Exists(path))
            {
                var options = new StaticFileOptions
                {
                    FileProvider = new PhysicalFileProvider(path),
                    RequestPath = new PathString("/docs")
                };

                app.UseStaticFiles(options);
            }

            return app;
        }

        /// <summary>
        /// 自定义Swagger
        /// </summary>
        /// <param name="app"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseCustomSwagger(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1.0/swagger.json", BasicSetting.Setting.AssemblyName);
            });
            return app;
        }

        /// <summary>
        /// 异常处理
        /// </summary>
        /// <param name="app"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseExceptionHandle(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionHandleMiddleware>();
            app.UseStatusCodePages(async context =>
            {
                if(context.HttpContext.Response.StatusCode != 200)
                {
                    context.HttpContext.Response.ContentType = "application/json"; ;
                    await context.HttpContext.Response.WriteAsync(
                        JsonHelper.SerializeJSON(ResultModel.Failed($"Status code page, status code: {context.HttpContext.Response.StatusCode}"))
                        );
                }
            });
            return app;
        }
    }
}
