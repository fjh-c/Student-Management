using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Primitives;
using System;
using System.IO;

namespace Microsoft.Extensions.Configuration
{
    public static class ConfigurationExtensions
    {
        /// <summary>
        /// 配置项绑定，使用热更新
        /// </summary>
        /// <param name="configuration"></param>
        /// <param name="instance"></param>
        public static void Binding(this IConfiguration configuration, object instance)
        {
            configuration.Bind(instance);

            //配置更改时重新绑定
            ChangeToken.OnChange(() => configuration.GetReloadToken(), () =>
            {
                configuration.Bind(instance);
                Console.WriteLine($"ConStr:{instance.ToString()}");
            });
        }

        /// <summary>
        /// 根据配置名称加载指定的配置项
        /// </summary>
        /// <param name="configuration"></param>
        /// <param name="filename">配置文件名称，使用约定，配置文件放在项目的config目录中，如logging配置：config/logging.json</param>
        /// <param name="env">宿主环境</param>
        /// <param name="reloadOnChange">开启热更新监听</param>
        /// <returns></returns>
        public static IConfiguration Load(this IConfiguration configuration, string filename, IWebHostEnvironment env, bool reloadOnChange = false)
        {
            var filePath = Path.Combine(AppContext.BaseDirectory, "Config");
            if (!Directory.Exists(filePath))
                return configuration;

            var builder = new ConfigurationBuilder()
                .SetBasePath(filePath)
                .AddJsonFile(filename.ToLower() + ".json", true, reloadOnChange);

            if (env.IsDevelopment())
            {
                builder.AddJsonFile(filename.ToLower() + "." + env.EnvironmentName + ".json", true, reloadOnChange);
            }
            return builder.Build();
        }
    }
}
