using ConstructionCompanyAPI.Util;
using ConstructionCompanyDataLayer;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace ConstructionCompanyAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IWebHostBuilder hostBuilder = CreateHostBuilder(args);
            IWebHost host = hostBuilder.Build();

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var context = services.GetRequiredService<ConstructionCompanyContext>();

                DBInitializer.Initialize(context);
            }

            host.Run();
        }

        public static IWebHostBuilder CreateHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}