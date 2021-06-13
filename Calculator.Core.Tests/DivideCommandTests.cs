using Calculator.Core.Abstracts;
using Calculator.Core.Commands;
using Calculator.Core.Dtos;
using FluentAssertions;
using NUnit.Framework;

namespace Calculator.Core.Tests
{
    public class DivideCommandTests
    {
        private ICalculator _calculator;
        private DivideCommand _subject;

        [SetUp]
        public void Setup()
        {
            _calculator = new BasicCalculator();
            _subject = new DivideCommand(_calculator);
        }        

        [TestCase(30, 2, 15)]
        [TestCase(40, 2, 20)]
        public void Execute_PassedTwoIntegers_RetunsResultAfterDivision(int num1, int num2, int expected)
        {
            var dto = new ExecuteDto(num1, num2);
            int result = _subject.Execute(dto);

            result.Should().Be(expected);
        }
    }
}
