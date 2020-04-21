using Autofac.Extensions.DependencyInjection;
using Logging.Serilog;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Serilog;
using Student.Core.API.Config;
using System;
using System.IO;

namespace Student.Core.API.Code.Core
{
    public class MyHostBuilder
    {

        /// <summary>
        /// 创建主机
        /// </summary>
        /// <typeparam name="TStartup"></typeparam>
        /// <param name="args">启动参数</param>
        /// <returns></returns>
        public IHostBuilder Create<TStartup>(string[] args) where TStartup : AutofacStartup
        {
            return CreateBuilder<TStartup>(args);
        }

        private IHostBuilder CreateBuilder<TStartup>(string[] args) where TStartup : AutofacStartup
        {
            if (BasicSetting.Setting.Urls.IsNull())
                BasicSetting.Setting.Urls = "http://*:5000";

            return Host.CreateDefaultBuilder(args)
                .UseServiceProviderFactory(new AutofacServiceProviderFactory())
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<TStartup>()
                    .UseLogging()
                    .UseUrls(BasicSetting.Setting.Urls);
                });
        }
    }
}
