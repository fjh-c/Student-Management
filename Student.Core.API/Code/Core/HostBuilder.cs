using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Student.Core.API.Config;
using System;
using System.IO;

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
            if (BasicSetting.Setting.Urls.IsNull())
                BasicSetting.Setting.Urls = "http://*:5000";

            return Host.CreateDefaultBuilder(args)
                .UseServiceProviderFactory(new AutofacServiceProviderFactory())
                .ConfigureAppConfiguration((hostingContext, config) =>
                {
                    var filePath = Path.Combine(AppContext.BaseDirectory, "Config");
                    //config.SetBasePath(filePath);
                    config.AddJsonFile(filePath+ "/initializationdata.json", optional: false, reloadOnChange: true);
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<TStartup>()
                    .UseUrls(BasicSetting.Setting.Urls);
                });
        }
    }
}
