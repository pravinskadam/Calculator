using Calculator.Core.Dtos;

namespace Calculator.Core.Abstracts
{
    public interface ICalculatorService
    {
        int Invoke(CalculateDto dto);
    }
}
