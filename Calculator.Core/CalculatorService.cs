using Calculator.Core.Abstracts;
using Calculator.Core.Constants;
using Calculator.Core.Dtos;
using System;

namespace Calculator.Core
{
    public class CalculatorService : ICalculatorService
    {
        private readonly Func<Operators, OperationCommand> _resolver;

        public CalculatorService(Func<Operators,OperationCommand> resolver)
        {
            
            _resolver = resolver;
        }

        public int Invoke(CalculateDto dto)
        {
            var id = (Operators)Enum.Parse(typeof(Operators), dto.Operator.ToUpper(), true);
            var command = _resolver(id);
            var exeDto = new ExecuteDto(dto.num1, dto.num2);
            return command.Execute(exeDto);            
        }
    }
}
