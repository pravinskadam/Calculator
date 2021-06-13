using System.Collections.Generic;
using System.Threading.Tasks;

namespace Calculator.Client.Abstracts
{
    public interface IFileReader
    {
        Task<IEnumerable<string>> ReadAsync(string filePath);
    }
}
