using FluentAssertions;
using NUnit.Framework;
using Calculator.Core.Dtos;
using System;
using Calculator.Core.Constants;
using Calculator.Core.Abstracts;
using Microsoft.Extensions.DependencyInjection;

namespace Calculator.Core.Tests
{
    public class CalculatorServiceTests
    {
        private CalculatorService _subject;
        
        [SetUp]
        public void Setup()
        {
            var resolver = TestManager.ServiceProvider
                .GetService<Func<Operators, OperationCommand>>();

            _subject = new CalculatorService(resolver);
        }

        [TestCase(20, 30, 50)]
        [TestCase(10, 20, 30)]
        public void Invoke_CalledWithAddOperatorAndTwoIntegers_ReturnsCorrectResult(int num1, int num2, int expected)
        {
            var dto = new CalculateDto("add", num1, num2);
            int result = _subject.Invoke(dto);

            result.Should().Be(expected);
        }

        [TestCase(50, 30, 20)]
        [TestCase(30, 20, 10)]
        public void Invoke_CalledWithSubtractOperatorAndTwoIntegers_ReturnsCorrectResult(int num1, int num2, int expected)
        {
            var dto = new CalculateDto("subtract", num1, num2);
            int result = _subject.Invoke(dto);

            result.Should().Be(expected);
        }

        [TestCase(2, 30, 60)]
        [TestCase(10, 20, 200)]
        public void Invoke_CalledWithMultiplyOperatorAndTwoIntegers_ReturnsCorrectResult(int num1, int num2, int expected)
        {
            var dto = new CalculateDto("multiply", num1, num2);
            int result = _subject.Invoke(dto);

            result.Should().Be(expected);
        }

        [TestCase(30, 2, 15)]
        [TestCase(10, 2, 5)]
        public void Invoke_CalledWithDivideOperatorAndTwoIntegers_ReturnsCorrectResult(int num1, int num2, int expected)
        {
            var dto = new CalculateDto("divide", num1, num2);
            int result = _subject.Invoke(dto);

            result.Should().Be(expected);
        }
    }
}