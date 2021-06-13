using System;
using System.Linq;
using System.Collections.Generic;
using Calculator.Client.Abstracts;

namespace Calculator.Client
{
    public class DataValidator : IValidator
    {
        public void Validate(IEnumerable<string> data)
        {
            if (data == null || !data.Any())
                throw new ArgumentNullException(string.Empty, message: "Value cannot be null or empty.");

            var operations = OperatorHelper.AllowedOperators();

            if (data.Any(x => !operations.Contains(x.Split(' ')[0].ToLower())))
                throw new InvalidOperationException("Invalid operator found in given data.");
            
            if (data.Last().Split(' ')[0].ToLower() != operations.Last())
                throw new InvalidOperationException($"Last instruction should be '{ operations.Last() }'.");

            if (data.Where(x => x.Split(' ')[0].ToLower() == operations.Last()).Count() > 1)
                throw new ArgumentException($"Only one 'apply' instruction is allowed.");
        }

        public void Validate(string row)
        {
            var cols = row.Split(' ');
            
            if (cols.Length > 2)
                throw new ArgumentException($"Too many whitespaces in row '{ row }'.");

            int.TryParse(cols[1].Trim(), out int value);

            if (value == 0)
                throw new ArgumentException($"Value cannot be 0 or non-numeric: '{ row }'");            
        }
    }
}
