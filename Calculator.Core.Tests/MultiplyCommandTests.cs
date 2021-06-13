using Calculator.Core.Abstracts;
using Calculator.Core.Commands;
using Calculator.Core.Dtos;
using FluentAssertions;
using NUnit.Framework;

namespace Calculator.Core.Tests
{
    public class MultiplyCommandTests
    {
        private ICalculator _calculator;
        private MultiplyCommand _subject;

        [SetUp]
        public void Setup()
        {
            _calculator = new BasicCalculator();
            _subject = new MultiplyCommand(_calculator);
        }

        [TestCase(30, 20, 600)]
        [TestCase(40, 20, 800)]
        public void Execute_PassedTwoIntegers_RetunsResultAfterMultiplication(int num1, int num2, int expected)
        {
            var dto = new ExecuteDto(num1, num2);
            int result = _subject.Execute(dto);

            result.Should().Be(expected);
        }
    }
}
