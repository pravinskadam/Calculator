using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using System;

namespace Calculator.Core.Tests
{
    [SetUpFixture]
    public class TestManager
    {
        public static IServiceProvider ServiceProvider;
        public static IConfiguration Configuration;

        [OneTimeSetUp]
        public void SetUp()
        {
            var builder = new ConfigurationBuilder();
            Configuration = builder.Build();

            var services = new ServiceCollection();
            services.AddSingleton(Configuration);
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