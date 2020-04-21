using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Student.Core.API.Code.Core;

namespace Student.Core.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Run();
        }
        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return new MyHostBuilder().Create<Startup>(args)
                .Configure("initializationdata", false, true)
                .Configure("logging", false, false);
        }
            
    }
}
