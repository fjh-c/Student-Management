using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Student.Core.API.Code.Core;

namespace Student.Core.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            new MyHostBuilder().Create<Startup>(args)
                .Configure("initializationdata", false, true)
                .Run();
        }
    }
}
