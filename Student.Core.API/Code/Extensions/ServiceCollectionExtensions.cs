using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Student.Core.API.Code.Filters;
using Student.Core.API.Config;
using Student.Model.Code;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
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
            //将控制器的寄宿器转为注册的服务
            services.AddControllers().AddControllersAsServices().AddNewtonsoftJson(options =>
            {
                //设置日期格式化
                options.SerializerSettings.DateFormatString = "yyyy-MM-dd HH:mm:ss";
            }).SetCompatibilityVersion(AspNetCore.Mvc.CompatibilityVersion.Version_3_0);
            services.AddOptions();

            //服务端缓存
            services.AddResponseCaching();

            //添加CORS
            services.AddCors(BasicSetting.Setting);

            //添加ORM
            services.AddORM(BasicSetting.Setting);

            //添加AutoMapper
            services.AddAutoMapper(typeof(Student.DTO.Profiles.AutoMapperProfiles).Assembly);

            //添加Swagger
            if (env.IsDevelopment())
            {
                services.AddSwagger();
            }

            return services;
        }

        /// <summary>
        /// 注册Swagger生成器
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1.0", new OpenApiInfo
                {
                    Title = BasicSetting.Setting.AssemblyName,
                    Description = "WebApi接口文档说明",
                    Version = "1.0",
                });
                //var filePath = Path.Combine(System.AppContext.BaseDirectory, "Student.Core.API/Swagger.Core.xml");
                //c.IncludeXmlComments(filePath);

                //var securityScheme = new OpenApiSecurityScheme
                //{
                //    Description = "JWT认证请求头格式: \"Authorization: Bearer {token}\"",
                //    Name = "Authorization",
                //    In = ParameterLocation.Header,
                //    Type = SecuritySchemeType.ApiKey,
                //    Scheme = "Bearer"
                //};

                ////添加设置Token的按钮
                //c.AddSecurityDefinition("Bearer", securityScheme);

                ////添加Jwt验证设置
                //c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                //{
                //    {
                //        new OpenApiSecurityScheme
                //        {
                //            Reference = new OpenApiReference
                //            {
                //                Type = ReferenceType.SecurityScheme,
                //                Id = "Bearer"
                //            },
                //            Scheme = "oauth2",
                //            Name = "Bearer",
                //            In = ParameterLocation.Header,

                //        },
                //        new List<string>()
                //    }
                //});

                //链接转小写过滤器
                c.DocumentFilter<LowercaseDocumentFilter>();

                //描述信息处理
                c.DocumentFilter<DescriptionDocumentFilter>();

                //隐藏属性
                c.SchemaFilter<IgnorePropertySchemaFilter>();
            });

            return services;
        }

        /// <summary>
        /// 添加CORS允许跨域访问
        /// </summary>
        /// <param name="services"></param>
        /// <param name="setting"></param>
        /// <returns></returns>
        public static IServiceCollection AddCors(this IServiceCollection services, BasicSetting setting)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("Default",
                    builder => builder.AllowAnyOrigin()
                        .SetPreflightMaxAge(new TimeSpan(0, 0, 180))
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .WithExposedHeaders("Content-Disposition"));//下载文件时，文件名称会保存在headers的Content-Disposition属性里面
            });
            services.AddCors(options =>
            {
                options.AddPolicy("AnotherPolicy",
                    builder => builder.WithOrigins(setting.WithOrigins)
                        .SetPreflightMaxAge(new TimeSpan(0, 0, 180))
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .WithExposedHeaders("Content-Disposition"));
            });
            return services;
        }

        /// <summary>
        /// 添加ORM
        /// </summary>
        /// <param name="services"></param>
        /// <param name="setting"></param>
        /// <returns></returns>
        public static IServiceCollection AddORM(this IServiceCollection services, BasicSetting setting)
        {
            if (setting.DbType == yrjw.ORM.Chimp.DbType.MYSQL)
            {
                services.AddChimp<myDbContext>(opt => opt.UseMySql(setting.ConnectionString,
                    b => b.MigrationsAssembly(setting.AssemblyName)));
            }
            else
            {
                services.AddChimp<myDbContext>(opt => opt.UseSqlServer(setting.ConnectionString,
                    b => b.MigrationsAssembly(setting.AssemblyName)));
            }
            return services;
        }
    }
}
