using System.Collections.Generic;

namespace Calculator.Client.Abstracts
{
    public interface IValidator
    {
        void Validate(IEnumerable<string> data);
        void Validate(string row);
    }
}
