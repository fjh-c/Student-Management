using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Primitives;
using System;
using System.IO;
using yrjw.CommonToolsCore.Helper;

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
        }

        
    }
}
