using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Primitives;
using System;
using System.IO;
using System.Linq;
using yrjw.CommonToolsCore.Helper;

namespace Microsoft.Extensions.Configuration
{
    public static class ConfigurationExtensions
    {
        /// <summary>
        /// 配置项绑定
        /// </summary>
        /// <typeparam name="T">配置项模型</typeparam>
        /// <param name="configuration"></param>
        /// <param name="key">key与配置项模型中静态属性名称要一致</param>
        /// <returns></returns>
        public static IConfiguration Binding<T>(this IConfiguration configuration, string key) where T: class
        {
            var pro = typeof(T).GetProperty(key);
            if (pro != null)
            {
                pro.SetValue(pro, configuration.GetSection(key).Get<T>());
            }
            else
            {
                Console.WriteLine($"To: error Binding<T> T={typeof(T).Name} key={key}");
            }
            return configuration;
        }

        public static void OnChange(this IConfiguration configuration, params object[] pms)
        {

            foreach (var item in pms)
            {
                var t = item.GetType().GetProperties();
                
                //获取Setting
            }

            //配置更改时重新绑定
            ChangeToken.OnChange(() => configuration.GetReloadToken(), () =>
            {
                foreach (object item in pms)
                {
                    var t = item.GetType();
                    configuration.GetSection("Setting").Get(item.GetType());
                }
                
                
                //BasicSetting.Setting = configuration.GetSection("Setting").Get<BasicSetting>();
                //InitializationData.Initialization = configuration.GetSection("Initialization").Get<InitializationData>();

                //Console.WriteLine($"To:{JsonHelper.SerializeJSON(BasicSetting.Setting)}");
                //Console.WriteLine($"To:{JsonHelper.SerializeJSON(InitializationData.Initialization)}");
            });
        }
    }
}
