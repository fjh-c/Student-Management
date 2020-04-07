using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Primitives;
using Student.Core.API.Config;
using Student.Model.Code;

namespace Student.Core.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            configuration.GetSection("Setting").Bind(BasicSetting.Setting);

            ChangeToken.OnChange(() => configuration.GetReloadToken(), () =>
            {
                configuration.GetSection("Setting").Bind(BasicSetting.Setting);
                Console.WriteLine($"Key1:{configuration["Key1"]}");
            });
        }

        public IConfiguration Configuration { get; }

        public ILifetimeScope AutofacContainer { get; private set; }

        // ConfigureContainer is where you can register things directly
        // with Autofac. This runs after ConfigureServices so the things
        // here will override registrations made in ConfigureServices.
        // Don't build the container; that gets done for you by the factory.
        public void ConfigureContainer(ContainerBuilder builder)
        {
            // Register your own things directly with Autofac, like:
            builder.RegisterModule<yrjw.ORM.Chimp.AutofacModule>();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers().AddControllersAsServices();
            services.AddOptions();
            // π”√ORM
            if (BasicSetting.Setting.DbType == yrjw.ORM.Chimp.DbType.MYSQL)
            {
                services.AddChimp<myDbContext>(opt => opt.UseMySql(BasicSetting.Setting.ConnectionString,
                    b => b.MigrationsAssembly("Student.Core.API")));
            }
            else
            {
                services.AddChimp<myDbContext>(opt => opt.UseSqlServer(BasicSetting.Setting.ConnectionString,
                    b => b.MigrationsAssembly("Student.Core.API")));
            }
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            this.AutofacContainer = app.ApplicationServices.GetAutofacRoot();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
