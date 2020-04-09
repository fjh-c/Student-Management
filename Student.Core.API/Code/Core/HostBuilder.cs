using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Student.Core.API.Code.Core
{
    public class HostBuilder
    {
        /// <summary>
        /// 启动
        /// </summary>
        /// <typeparam name="TStartup"></typeparam>
        /// <param name="args">启动参数</param>
        public void Run<TStartup>(string[] args) where TStartup : AutofacStartup
        {
            CreateBuilder<TStartup>(args).Build().Run();
        }

        private IHostBuilder CreateBuilder<TStartup>(string[] args) where TStartup : AutofacStartup
        {
            return Host.CreateDefaultBuilder(args)
                .UseServiceProviderFactory(new AutofacServiceProviderFactory())
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<TStartup>()
                    .UseUrls("http://*:5000");
                });
        }
    }
}
