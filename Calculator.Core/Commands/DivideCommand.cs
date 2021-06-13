using Calculator.Core.Abstracts;
using Calculator.Core.Dtos;

namespace Calculator.Core.Commands
{
    public class DivideCommand : OperationCommand
    {
        public DivideCommand(ICalculator calculator)
            : base(calculator)
        {
        }

        public override int Execute(ExecuteDto dto)
        {
            return _calculator.Divide(dto.num1, dto.num2);
        }
    }
}
