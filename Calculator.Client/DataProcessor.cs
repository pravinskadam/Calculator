using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Calculator.Core.Abstracts;
using Calculator.Client.Abstracts;
using Microsoft.Extensions.Configuration;

namespace Calculator.Client
{
    public class DataProcessor : IProcessor
    {
        private readonly IValidator _validator;
        private readonly IFileReader _fileReader;
        private readonly IConfiguration _configuration;
        private readonly ICalculatorService _calculatorService;

        public DataProcessor(IValidator validator, IFileReader fileReader, 
            IConfiguration configuration, ICalculatorService calculatorService)
        {
            _validator = validator;
            _fileReader = fileReader;
            _configuration = configuration;
            _calculatorService = calculatorService;
        }        

        public async Task<int> ProcessAsync()
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), 
                _configuration.GetSection("AppSettings:DataFeed:FilePath").Value);

            var data = await _fileReader.ReadAsync(filePath);

            _validator.Validate(data);
            return Process(data);
        }

        private int Process(IEnumerable<string> data)
        {
            int result = ConvertToKeyValuePair(data.Last()).Value;

            Console.WriteLine($"base number:- {result}");

            foreach (var row in data.SkipLast(1))
            {
                _validator.Validate(row);
                var kvp = ConvertToKeyValuePair(row);
                Console.WriteLine($"Input:- {kvp.Key}-{kvp.Value}");
                result = _calculatorService.Invoke(new(kvp.Key, result, kvp.Value));
            }

            WriteDashes();
            Console.WriteLine($"Result:- {result}");
            WriteDashes();

            return result;
        }
        
        private KeyValuePair<string, int> ConvertToKeyValuePair(string row)
        {
            var cols = row.Split(' ');
            var key = cols[0].ToLower();
            var value = int.Parse(cols[1].Trim());
            return new KeyValuePair<string, int>(key, value);
        }

        private static void WriteDashes()
        {
            Console.WriteLine(string.Concat(Enumerable.Repeat("-", 25)));
        }
    }
}
