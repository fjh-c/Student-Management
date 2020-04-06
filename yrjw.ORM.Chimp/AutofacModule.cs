using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Autofac;

namespace yrjw.ORM.Chimp
{
    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var assemblies = ReflectionHelper.GetAllAssembliesCoreWeb();

            //注册Service和Controller
            builder.RegisterAssemblyTypes(assemblies).Where(t => t.Name.EndsWith("Service") |
                                                      t.HasImplementedRawGeneric(typeof(IDependency)) && t.IsClass)
                                                      .PublicOnly().AsImplementedInterfaces();
            builder.RegisterAssemblyTypes(assemblies).Where(t => t.Name.EndsWith("Controller")).PropertiesAutowired();
        }
    }
}
