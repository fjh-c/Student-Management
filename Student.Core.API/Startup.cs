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
using Student.Core.API.Code.Core;
using Student.Core.API.Config;
using Student.Model.Code;

namespace Student.Core.API
{
    public class Startup: AutofacStartup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment env) : base(env)
        {
            //��������Ϣ
            configuration.Binding<BasicSetting>("Setting")
                .Binding<InitializationData>("Initialization")
                .OnChange(BasicSetting.Setting, InitializationData.Initialization);
        }
    }
}
