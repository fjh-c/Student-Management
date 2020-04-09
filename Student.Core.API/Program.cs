using Student.Core.API.Code.Core;

namespace Student.Core.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            new HostBuilder().Run<Startup>(args);
        }
    }
}
