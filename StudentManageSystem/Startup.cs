using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using StudentManageSystem.Code.WebApi;
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
            //添加HttpClient相关
            services.AddSingleton<IHttpApiFactory<IWebApiHelper>, HttpApiFactory<IWebApiHelper>>(p =>
            {
                return new HttpApiFactory<IWebApiHelper>().ConfigureHttpApiConfig(c =>
                {
                    // Api 地址
                    c.HttpHost = new Uri(StudentManageSystemSetting.Setting.ApiUrl);
                });
            });
            services.AddTransient(p =>
            {
                var factory = p.GetRequiredService<IHttpApiFactory<IWebApiHelper>>();
                return factory.CreateHttpApi();
            });
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
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=MainPC}/{id?}");
            });
        }
    }
}
