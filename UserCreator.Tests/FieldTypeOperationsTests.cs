using Moq;
using System.IO;
using System.Threading.Tasks;
using Xunit;

namespace UserCreator.Tests
{
    public class FieldTypeOperationsTests
    {
        [Fact]
        public async Task TryToWriteToFile_FieldTypeSalary_DataWrittenSuccess()
        {
            // Arrange

            var streamWriterMock = new Mock<StreamWriter>("output.txt");
            var fieldTypeOperations = new FieldTypeOperations(new WriteUserDataToFile());

            // Act

            await fieldTypeOperations.FieldTypeOperation("salary", "5000", streamWriterMock.Object);

            // Assert

            streamWriterMock.Verify(a => a.WriteLineAsync("1,salary,5000"), Times.Exactly(1));
        }

        [Fact]
        public async Task TryToWriteToFile_FieldTypeSalary_DataWrittenInvalid()
        {
            // Arrange

            var streamWriterMock = new Mock<StreamWriter>("output.txt");
            var fieldTypeOperations = new FieldTypeOperations(new WriteUserDataToFile());

            // Act

            await fieldTypeOperations.FieldTypeOperation("salary", "5000", streamWriterMock.Object);

            // Assert

            streamWriterMock.Verify(a => a.WriteLineAsync("1,salary,1000"), Times.Exactly(1));
        }
    }
}
