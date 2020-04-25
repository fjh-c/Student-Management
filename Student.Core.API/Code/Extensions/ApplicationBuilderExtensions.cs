using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Student.Core.API.Code.Middleware;
using Student.Core.API.Config;
using System;
using System.Collections.Generic;
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

            //app.UseStaticFiles();
            //app.UseHttpsRedirection();

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
