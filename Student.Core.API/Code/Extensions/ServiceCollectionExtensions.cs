using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Student.Core.API.Config;
using Student.Model.Code;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// 添加WebHost
        /// </summary>
        /// <param name="services"></param>
        /// <param name="env">环境</param>
        /// <returns></returns>
        public static IServiceCollection AddWebHost(this IServiceCollection services, IWebHostEnvironment env)
        {
            services.AddControllers().AddControllersAsServices();
            services.AddOptions();
            //使用ORM
            if (BasicSetting.Setting.DbType == yrjw.ORM.Chimp.DbType.MYSQL)
            {
                services.AddChimp<myDbContext>(opt => opt.UseMySql(BasicSetting.Setting.ConnectionString,
                    b => b.MigrationsAssembly(BasicSetting.Setting.AssemblyName)));
            }
            else
            {
                services.AddChimp<myDbContext>(opt => opt.UseSqlServer(BasicSetting.Setting.ConnectionString,
                    b => b.MigrationsAssembly(BasicSetting.Setting.AssemblyName)));
            }

            //注册 Swagger 生成器，定义一个和多个 Swagger 文档
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1.0", new OpenApiInfo
                {
                    Title = BasicSetting.Setting.AssemblyName,
                    Description = "WebApi接口文档说明",
                    Version = "1.0",
                });
                var filePath = Path.Combine(System.AppContext.BaseDirectory, "Student.Core.API/Swagger.Core.xml");
                c.IncludeXmlComments(filePath);
            });
            return services;
        }
    }
}
