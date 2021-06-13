using Calculator.Core.Abstracts;
using Calculator.Core.Commands;
using Calculator.Core.Dtos;
using FluentAssertions;
using NSubstitute;
using NUnit.Framework;

namespace Calculator.Core.Tests
{
    public class AddCommandTests
    {
        private ICalculator _calculator;
        private AddCommand _subject;

        [SetUp]
        public void Setup()
        {
            _calculator = new BasicCalculator();
            _subject = new AddCommand(_calculator);
        }

        [TestCase(20, 30, 50)]
        [TestCase(10, 20, 30)]
        public void Execute_PassedTwoIntegers_RetunsResultAfterAddition(int num1, int num2, int expected)
        {
            
            var dto = new ExecuteDto(num1, num2);
            int result = _subject.Execute(dto);

            result.Should().Be(expected);
        }
    }
}
