using FluentAssertions;
using NUnit.Framework;

namespace Calculator.Core.Tests
{
    public class BasicCalculatorTests
    {
        private BasicCalculator _subject;

        [SetUp]
        public void Setup()
        {
            _subject = new BasicCalculator();
        }

        [TestCase(20, 30, 50)]
        [TestCase(10, 20, 30)]
        public void Add_PassedTwoIntegers_RetunsResultAfterAddition(int num1, int num2, int expected)
        {
            int result = _subject.Add(num1, num2);
            
            result.Should().Be(expected);            
        }

        [TestCase(10, 20, -10)]
        [TestCase(30, 20, 10)]
        [TestCase(40, 20, 20)]        
        public void Subtract_PassedTwoIntegers_RetunsResultAfterSubtraction(int num1, int num2, int expected)
        {
            int result = _subject.Subtract(num1, num2);

            result.Should().Be(expected);
        }

        [TestCase(30, 20, 600)]
        [TestCase(40, 20, 800)]
        public void Multiply_PassedTwoIntegers_RetunsResultAfterMultiplication(int num1, int num2, int expected)
        {
            int result = _subject.Multiply(num1, num2);

            result.Should().Be(expected);
        }

        [TestCase(30, 2, 15)]
        [TestCase(40, 2, 20)]
        public void Divide_PassedTwoIntegers_RetunsResultAfterDivision(int num1, int num2, int expected)
        {
            int result = _subject.Divide(num1, num2);

            result.Should().Be(expected);
        }
    }
}