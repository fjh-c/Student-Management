using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WebApiClient;

namespace StudentManageSystem
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //RazorRuntimeCompilation 运行时编译 
            services.AddControllersWithViews().AddRazorRuntimeCompilation();

            //使用Session
            services.AddSession();

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
              .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, options =>
              {
                  options.LoginPath = new PathString("/Login/Index");
                  options.LogoutPath = new PathString("/Login/Logout");
                  options.AccessDeniedPath = new PathString("/Home/Error");
                  options.Cookie.Name = "_AdminTicketCookie";
                  options.Cookie.SameSite = SameSiteMode.None;

                  //当Cookie 过期时间已达一半时，是否重置为ExpireTimeSpan
                  options.SlidingExpiration = true;
                  options.Cookie.HttpOnly = true;
              });

            //添加HttpClient相关
            var types = typeof(Startup).Assembly.GetTypes()
                        .Where(type => type.IsInterface
                        && ((System.Reflection.TypeInfo)type).ImplementedInterfaces != null
                        && type.GetInterfaces().Any(a => a.FullName == typeof(IHttpApi).FullName));
            foreach (var type in types)
            {
                services.AddHttpApi(type);
                services.ConfigureHttpApi(type, o => {
                    o.HttpHost = new Uri(StudentManageSystemSetting.Setting.ApiUrl);
                });
            } 
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseRouting();
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseSession();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=MainPC}/{id?}");
            });
            app.UseCookiePolicy();
        }
    }
}
