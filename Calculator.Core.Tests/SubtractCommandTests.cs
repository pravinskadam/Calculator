using Calculator.Core.Abstracts;
using Calculator.Core.Commands;
using Calculator.Core.Dtos;
using FluentAssertions;
using NUnit.Framework;

namespace Calculator.Core.Tests
{
    public class SubtractCommandTests
    {
        private ICalculator _calculator;
        private SubtractCommand _subject;

        [SetUp]
        public void Setup()
        {
            _calculator = new BasicCalculator();
            _subject = new SubtractCommand(_calculator);
        }

        [TestCase(10, 20, -10)]
        [TestCase(30, 20, 10)]
        [TestCase(40, 20, 20)]
        public void Execute_PassedTwoIntegers_RetunsResultAfterSubtraction(int num1, int num2, int expected)
        {
            var dto = new ExecuteDto(num1, num2);
            int result = _subject.Execute(dto);

            result.Should().Be(expected);
        }
    }
}
