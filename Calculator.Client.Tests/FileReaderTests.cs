using FluentAssertions;
using NUnit.Framework;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Calculator.Client.Tests
{
    public class FileReaderTests
    {
        private FileReader _subject;

        [SetUp]
        public void Setup()
        {
            _subject = new FileReader();
        }

        [Test]
        public void ReadAsync_CalledWithInvalidFilePath_ThrowsFileNotFoundException()
        {
            Func<Task> act = async () =>
            {
                await _subject.ReadAsync(string.Empty);
            };

            act.Should().Throw<FileNotFoundException>()
                .WithMessage("Unable to find the specified file.");
        }

        [Test]
        public async Task ReadAsync_CalledWithValidPath_ReturnsFileContents()
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), 
                "testFiles", "fileReader", "ReadAsync_CalledWithValidPath_ReturnsFileContents.txt");            

            var result = await _subject.ReadAsync(filePath);

            result.Should().NotBeEmpty();
            result.Should().BeEquivalentTo(new[] { "File for test case: ReadAsync_CalledWithValidPath_ReturnsFileContents" });
        }
    }
}