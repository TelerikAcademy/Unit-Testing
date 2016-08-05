namespace Cosmetics.Tests.Engine
{
    using System;
    using System.Collections.Generic;

    using Cosmetics.Engine;
    using NUnit.Framework;

    [TestFixture]
    public class CommandTests
    {
        [Test]
        public void Parse_WhenInputParamIsValid_ShouldReturnNewCommandInstance()
        {
            // Arrange
            var validInput = "AddToCategory ForMale Cool";

            // Act
            var executionResult = Command.Parse(validInput);

            // Assert
            Assert.IsInstanceOf<Command>(executionResult);
        }

        [Test]
        public void Parse_WhenInputParamIsNull_ShouldThrowNullReferenceException()
        {
            // Act && Assert
            Assert.Throws<NullReferenceException>(() => Command.Parse(null));
        }

        [Test]
        public void Parse_WhenInputParamIsValid_ShouldCorrectlySetNameProperty()
        {
            // Arrange
            var validInput = "AddToCategory ForMale Cool";
            var expectedNamePropertyValue = "AddToCategory";

            // Act
            var executionResult = Command.Parse(validInput);

            // Assert
            Assert.AreEqual(expectedNamePropertyValue, executionResult.Name);
        }

        [Test]
        public void Parse_WhenInputParamIsValid_ShouldCorrectlySetParametersProperty()
        {
            // Arrange
            var validInput = "AddToCategory ForMale Cool";
            var expectedParametersPropertyValue = new List<string>() { "ForMale", "Cool" };

            // Act
            var executionResult = Command.Parse(validInput);

            // Assert
            CollectionAssert.AreEqual(expectedParametersPropertyValue, executionResult.Parameters);
        }

        [Test]
        public void Parse_WhenInputParamHasInvalidName_ShouldThrowArgumentNullExceptionWithCorrectMessage()
        {
            // Arrange
            var invalidInput = " ForMale Cool";

            // Act && Assert
            Assert.That(() => Command.Parse(invalidInput), Throws.ArgumentNullException.With.Message.Contains("Name"));
        }

        [Test]
        public void Parse_WhenInputParamHasInvalidParameters_ShouldThrowArgumentNullExceptionWithCorrectMessage()
        {
            // Arrange
            var invalidInput = "AddToCategory ";

            // Act && Assert
            Assert.That(() => Command.Parse(invalidInput), Throws.ArgumentNullException.With.Message.Contains("List"));
        }
    }
}
