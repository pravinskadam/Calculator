using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Calculator.Client.Tests
{
    public class DataValidatorTests
    {
        private DataValidator _subject;

        [SetUp]
        public void Setup()
        {
            _subject = new DataValidator();
        }

        [Test]
        public void Validate_ReceivesNoContents_ThrowsArgumentNullException() 
        {
            IEnumerable<string> data = null;

            Action act = () =>
            {
                _subject.Validate(data);
            };

            act.Should().Throw<ArgumentNullException>()
                .WithMessage("Value cannot be null or empty.");
        }

        [Test]
        public void Validate_ReceivesContentsWithInvalidOperation_ThrowsInvalidOperationException()
        {
            var data = new [] { 
                "add 1",
                "sub 2",
                "apply 3"
            };
            
            Action act = () =>
            {
                _subject.Validate(data);
            };

            act.Should().Throw<InvalidOperationException>()
                .WithMessage("Invalid operator found in given data.");
        }

        [Test]
        public void Validate_ReceivesContentsWithMoreThanOneApply_ThrowsInvalidOperationException()
        {
            var data = new[] {
                "add 1",
                "subtract 2",
                "apply 3",
                "apply 4"
            };

            Action act = () =>
            {
                _subject.Validate(data);
            };

            act.Should().Throw<ArgumentException>()
                .WithMessage($"Only one 'apply' instruction is allowed.");
        }

        [Test]
        public void Validate_ReceivesContentsWithNoApplyOperation_ThrowsInvalidOperationException()
        {
            var data = new[] {
                "add 1",
                "multiply 2"
            };

            Action act = () =>
            {
                _subject.Validate(data);
            };

            act.Should().Throw<InvalidOperationException>()
                .WithMessage("Last instruction should be 'apply'.");
        }

        [TestCase("add   1  ")]
        [TestCase("add 1 ")]
        [TestCase("add  1")]
        public void Validate_ReceivesContentsWithExtraWhitespaces_ThrowsArgumentException(string data)
        {
            Action act = () =>
            {
                _subject.Validate(data);
            };

            act.Should().Throw<ArgumentException>()
                .WithMessage($"Too many whitespaces in row '{ data }'.");
        }
                
        [TestCase("add One")]
        [TestCase("add 0")]
        public void Validate_ReceivesContentsWithZeroOrNonNumericValue_ThrowsArgumentException(string data)
        {
            Action act = () =>
            {
                _subject.Validate(data);
            };

            act.Should().Throw<ArgumentException>()
                .WithMessage($"Value cannot be 0 or non-numeric: '{ data }'");
        }
    }
}
