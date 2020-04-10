using Autofac;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Student.Core.API.Config;

namespace Student.Core.API.Code.Core
{
    public class AutofacStartup
    {
        public AutofacStartup(IWebHostEnvironment env)
        {
            Env = env;
        }

        public IWebHostEnvironment Env { get; }

        public ILifetimeScope AutofacContainer { get; protected set; }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterModule<yrjw.ORM.Chimp.AutofacModule>();
        }
    }
}
