using Microsoft.Extensions.Configuration;
using Sampler.ConsoleApplication;
using System;
using System.Threading.Tasks;

namespace Energy.Samples
{
    /// <summary>
    /// Entry point class
    /// </summary>
    class Program
    {
        /// <summary>
        /// Entry point method.
        /// </summary>
        /// <returns>A Task to support asynchronous behavior.</returns>
        static async Task Main()
        {
            // Build configuration
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", false)
                .Build();

            // Generate the Service Provider
            IServiceProvider serviceProvider = new Startup(config).ConfigureServices();

            try
            {
                // Run the program
                await new SampleProgram(serviceProvider).Run();
            }
            catch (Exception e)
            {
                Console.Clear();
                Console.WriteLine("Encountered unhandled exception:");
                Console.WriteLine(e.Message);
            }
        }
    }
}
