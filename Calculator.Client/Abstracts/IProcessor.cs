using System.Threading.Tasks;

namespace Calculator.Client.Abstracts
{
    public interface IProcessor
    {
        Task<int> ProcessAsync();
    }
}
