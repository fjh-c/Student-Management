using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Student.Core.API.Config;

namespace Student.Core.API.Code.Core
{
    public abstract class AutofacStartup
    {
        public AutofacStartup(IWebHostEnvironment env)
        {
            Env = env;
        }
        protected readonly IWebHostEnvironment Env;

        protected ILifetimeScope AutofacContainer { get; set; }

        public virtual void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterModule<yrjw.ORM.Chimp.AutofacModule>();
        }

        public virtual void ConfigureServices(IServiceCollection services)
        {
            services.AddWebHost(Env);
        }

        public virtual void Configure(IApplicationBuilder app)
        {
            AutofacContainer = app.ApplicationServices.GetAutofacRoot();
            app.UseWebHost(Env, AutofacContainer);
        }
    }
}
