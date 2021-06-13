using Calculator.Core.Dtos;

namespace Calculator.Core.Abstracts
{
    public abstract class OperationCommand
    {
        protected readonly ICalculator _calculator;

        public OperationCommand(ICalculator calculator)
        {
            _calculator = calculator;
        }

        public abstract int Execute(ExecuteDto dto);
    }
}
