using Consolater;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Energy.Samples
{
    class Program
    {
        static async Task Main()
        {
            // Build configuration
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", false)
                .AddJsonFile($"appsettings.{EnvironmentName}.json", true)
                .Build();

            // Generate the Service Provider
            IServiceProvider serviceProvider = new Startup(config).ConfigureServices();

            try
            {
                // Run the program
                await new ConsoleAppProgram(serviceProvider).Run();
            }
            catch (Exception e)
            {
                Console.Clear();
                Console.WriteLine("Encountered unhandled exception:");
                Console.WriteLine(e.Message);
                Console.ReadLine();
            }
        }

        private static string EnvironmentName => Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
    }
}
