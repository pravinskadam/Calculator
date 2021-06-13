using Calculator.Client.Abstracts;
using Microsoft.Extensions.DependencyInjection;

namespace Calculator.Client
{
    public static partial class Extensions
    {
        public static void RegisterCalculatorClientServices(this IServiceCollection services)
        {
            services.AddScoped<IValidator, DataValidator>();
            services.AddScoped<IFileReader, FileReader>();
            services.AddScoped<IProcessor, DataProcessor>();
        }
    }
}
