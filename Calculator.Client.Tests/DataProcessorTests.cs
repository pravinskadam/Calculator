using NSubstitute;
using NUnit.Framework;
using FluentAssertions;
using System.Threading.Tasks;
using Calculator.Client.Abstracts;
using Calculator.Core.Abstracts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Collections;

namespace Calculator.Client.Tests
{
    public class DataProcessorTests
    {
        private IValidator _validator;
        private IFileReader _fileReader;
        private IConfiguration _configuration;
        private DataProcessor _subject;            
        
        [SetUp]
        public void SetUp()
        {
            _validator = Substitute.For<IValidator>();
            _fileReader = Substitute.For<IFileReader>();
            _configuration = Substitute.For<IConfiguration>();
            
            var calculatorService = TestManager.ServiceProvider.GetService<ICalculatorService>();

            _subject = new DataProcessor(_validator, _fileReader, _configuration, calculatorService);
        }
                
        [TestCaseSource(typeof(CalculatorTestDataSource))]
        public async Task ProcessAsync_ReceivesValidData_ReturnResult(TestRecord rec) 
        {
            _configuration.GetSection("AppSettings:DataFeed:FilePath").Value.Returns("mydata.txt");
            _fileReader.ReadAsync(Arg.Any<string>()).ReturnsForAnyArgs(rec.Data);

            var result = await _subject.ProcessAsync();

            result.Should().Be(rec.Result);            
        }

        #region "Test Data Setup"
        public record TestRecord (string[] Data, int Result);

        private class CalculatorTestDataSource : IEnumerable
        {
            public IEnumerator GetEnumerator()
            {
                yield return new TestRecord(new[] {
                    "Add 1",
                    "Add 3",
                    "Subtract 4",
                    "Apply 5"
                    }, 5);

                yield return new TestRecord(new[] {
                    "Add 1",
                    "Multiply 3",
                    "Subtract 4",
                    "Apply 10"
                    }, 29);

                yield return new TestRecord(new[] {
                    "Add 1",
                    "Divide 2",
                    "Multiply 4",
                    "Apply 5"
                    }, 12);
            }
        }
        #endregion "Test Data Setup"
    }
}

