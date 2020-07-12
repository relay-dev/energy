using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;

namespace Energy.Samples
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        /// <summary>
        /// Configure DI and initialize other services needed to run the application
        /// </summary>
        /// <returns></returns>
        public IServiceProvider ConfigureServices()
        {
            // Initialize a ServiceCollection and add logging
            var serviceCollection = new ServiceCollection()
                .AddLogging(builder =>
                {
                    builder.AddConfiguration(_configuration.GetSection("Logging"));
                    builder.AddConsole();
                });

            // Add other services needed to run the application
            serviceCollection.AddSingleton(_configuration);
            serviceCollection.AddTransient<DataStructureSamples>();
            serviceCollection.AddTransient<ServiceSamples>();

            // Build the IServiceProvider
            IServiceProvider serviceProvider = serviceCollection.BuildServiceProvider();

            return serviceProvider;
        }
    }
}
