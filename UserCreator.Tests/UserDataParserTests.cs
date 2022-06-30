using System;
using Xunit;

namespace UserCreator.Tests
{
    public class UserDataParserTests
    {
        [Fact]
        public void TryToConvertData_FieldTypeSalary_ValidDataTypeReturnTrue()
        {
            // Arrange

            var userDataParser = new UserDataParser<decimal>();

            var fieldData = 5000;

            // Act

            var result = userDataParser.TryConvertData(fieldData.ToString(), out var data);

            // Assert

            Assert.True(result);
            Assert.Equal(fieldData, data);
        }

        [Fact]
        public void TryToConvertData_FieldTypeSalary_InValidDataTypeReturnFalse()
        {
            // Arrange

            var userDataParser = new UserDataParser<decimal>();

            var fieldData = "invlid salary";

            // Act

            var result = userDataParser.TryConvertData(fieldData.ToString(), out var data);

            // Assert

            Assert.False(result);
        }

        [Fact]
        public void TryToConvertData_FieldTypeDateOfBirth_ValidDataTypeReturnTrue()
        {
            // Arrange

            var userDataParser = new UserDataParser<DateTime>();

            var fieldData = "6/30/2022";

            // Act

            var result = userDataParser.TryConvertData(fieldData.ToString(), out var data);

            // Assert

            Assert.True(result);
            Assert.Equal(Convert.ToDateTime(fieldData), data);
        }

        [Fact]
        public void TryToConvertData_FieldTypeDateOfBirth_InValidDataTypeReturnFalse()
        {
            // Arrange

            var userDataParser = new UserDataParser<DateTime>();

            var fieldData = "15/30/2022";

            // Act

            var result = userDataParser.TryConvertData(fieldData.ToString(), out var data);

            // Assert

            Assert.False(result);
        }

        [Fact]
        public void TryToConvertData_FieldTypeString_ValidStringTypeReturnFalse()
        {
            // Arrange

            var userDataParser = new UserDataParser<string>();

            var fieldData = "15/30/2022";

            // Act

            var result = userDataParser.TryConvertData(fieldData.ToString(), out var data);

            // Assert

            Assert.True(result);
            Assert.Equal(fieldData, data);
        }
    }
}