using Microsoft.Extensions.Primitives;
using Student.Core.API.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.Extensions.Configuration
{
    public static class ConfigurationExtensions
    {
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
    }
}
