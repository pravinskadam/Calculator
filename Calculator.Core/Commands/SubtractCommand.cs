using Calculator.Core.Abstracts;
using Calculator.Core.Dtos;

namespace Calculator.Core.Commands
{
    public class SubtractCommand : OperationCommand
    {
        public SubtractCommand(ICalculator calculator)
            : base(calculator)
        {
        }

        public override int Execute(ExecuteDto dto)
        {
            return _calculator.Subtract(dto.num1, dto.num2);
        }
    }
}
