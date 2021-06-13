using Calculator.Core.Abstracts;
using Calculator.Core.Dtos;

namespace Calculator.Core.Commands
{
    public class MultiplyCommand : OperationCommand
    {
        public MultiplyCommand(ICalculator calculator)
            : base(calculator)
        {
        }

        public override int Execute(ExecuteDto dto)
        {
            return _calculator.Multiply(dto.num1, dto.num2);
        }
    }
}
