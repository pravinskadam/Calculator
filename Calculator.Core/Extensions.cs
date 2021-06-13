using System;
using Calculator.Core.Commands;
using Calculator.Core.Constants;
using Calculator.Core.Abstracts;
using Microsoft.Extensions.DependencyInjection;

namespace Calculator.Core
{
    public static partial class Extensions
    {
        public static void RegisterCalculatorCoreServices(this ServiceCollection services)
        {
            services.AddSingleton<AddCommand>();
            services.AddSingleton<SubtractCommand>();
            services.AddSingleton<MultiplyCommand>();
            services.AddSingleton<DivideCommand>();
            services.AddScoped<ICalculator, BasicCalculator>();
            services.AddScoped<ICalculatorService, CalculatorService>();

            services.AddTransient<Func<Operators, OperationCommand>>(provider => key =>
            {
                switch (key)
                {
                    case Operators.ADD:
                        return provider.GetService<AddCommand>();
                    case Operators.SUBTRACT:
                        return provider.GetService<SubtractCommand>();
                    case Operators.MULTIPLY:
                        return provider.GetService<MultiplyCommand>();
                    case Operators.DIVIDE:
                        return provider.GetService<DivideCommand>();
                    default:
                        return null;
                }
            });
        }        
    }
}
