using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Calculator.Core;
using Calculator.Client.Abstracts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Calculator.Client
{
    class Program
    {
        private static IServiceProvider _serviceProvider;
        private static IConfiguration _configuration;

        static async Task Main(string[] args)
        {
            InitializeConfigurationBuilder();
            InitializeServiceProvider();
                        
            var processor = _serviceProvider.GetService<IProcessor>();

            Console.WriteLine("Welcome to Basic Calculator");
            WriteDashes();
            ConsoleKey consoleKey;

            do
            {
                try
                {
                    await processor.ProcessAsync();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
                Console.WriteLine("Press esc key to exit; or press any key to re-run!");
                Console.WriteLine("You can run another test by editing data.txt file; no need to close this window!");
                consoleKey = Console.ReadKey().Key;
                WriteDashes();
            } while (consoleKey != ConsoleKey.Escape);

            DisposeServiceProvider();
        }
        
        private static void InitializeServiceProvider()
        {
            var services = new ServiceCollection();
            services.AddSingleton(_configuration);
            services.RegisterCalculatorClientServices();
            services.RegisterCalculatorCoreServices();
            _serviceProvider = services.BuildServiceProvider();
        }

        private static void InitializeConfigurationBuilder()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            _configuration = builder.Build();
        }

        private static void DisposeServiceProvider()
        {
            if (_serviceProvider == null)
                return;

            if (_serviceProvider is IDisposable)
                ((IDisposable)_serviceProvider).Dispose();
        }

        private static void WriteDashes()
        {
            Console.WriteLine(string.Concat(Enumerable.Repeat("-", 100)));
        }
    }
}
