using Calculator.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using System;
using System.IO;

namespace Calculator.Client.Tests
{
    [SetUpFixture]
    public class TestManager
    {
        public static IServiceProvider ServiceProvider;
        public static IConfiguration Configuration;

        [OneTimeSetUp]
        public void SetUp()
        {
            var builder = new ConfigurationBuilder()
              .SetBasePath(Directory.GetCurrentDirectory())
              .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            Configuration = builder.Build();

            var services = new ServiceCollection();
            services.AddSingleton(Configuration);
            services.RegisterCalculatorClientServices();
            services.RegisterCalculatorCoreServices();
            ServiceProvider = services.BuildServiceProvider();
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            if (ServiceProvider == null)
                return;
            if (ServiceProvider is IDisposable)
                ((IDisposable)ServiceProvider).Dispose();
        }
    }
}
