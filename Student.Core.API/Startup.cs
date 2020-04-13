using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Primitives;
using Student.Core.API.Code.Core;
using Student.Core.API.Config;
using Student.Model.Code;
using yrjw.CommonToolsCore.Helper;

namespace Student.Core.API
{
    public class Startup: AutofacStartup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment env) : base(env)
        {
            configuration.Binding<BasicSetting>("Setting")
                .Binding<InitializationData>("Initialization")
                .OnChange(BasicSetting.Setting, InitializationData.Initialization);

        }

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

        public void Configure(IApplicationBuilder app)
        {
            if (Env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            base.AutofacContainer = app.ApplicationServices.GetAutofacRoot();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
