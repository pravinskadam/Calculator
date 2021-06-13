using Calculator.Core.Abstracts;
using Calculator.Core.Dtos;

namespace Calculator.Core.Commands
{
    public class AddCommand : OperationCommand
    {
        public AddCommand(ICalculator calculator) 
            : base(calculator)
        {            
        }

        public override int Execute(ExecuteDto dto)
        {
            return _calculator.Add(dto.num1, dto.num2);
        }
    }
}
