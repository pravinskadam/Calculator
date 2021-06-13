using Calculator.Client.Abstracts;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Calculator.Client
{
    public class FileReader : IFileReader
    {
        public async Task<IEnumerable<string>> ReadAsync(string filePath)
        {
            if (!File.Exists(filePath))
                throw new FileNotFoundException("Unable to find the specified file.");

            return await File.ReadAllLinesAsync(filePath);
        }
    }
}
