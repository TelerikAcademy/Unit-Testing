namespace Cosmetics.Tests.Common
{
    using System;

    using Cosmetics.Common;
    using NUnit.Framework;

    [TestFixture]
    public class ValidatorTests
    {
        [Test]
        public void CheckIfNull_WhenObjParamIsNull_ShouldThrowNullReferenceException()
        {
            // Arrange
            object objectToTest = null;

            // Act && Assert
            Assert.Throws<NullReferenceException>(() => Validator.CheckIfNull(objectToTest));
        }

        [Test]
        public void CheckIfNull_WhenObjParamIsValid_ShouldNotThrow()
        {
            // Arrange
            object objectToTest = new object();

            // Act && Assert
            Assert.DoesNotThrow(() => Validator.CheckIfNull(objectToTest));
        }

        [TestCase("")]
        [TestCase(null)]
        public void CheckIfStringIsNullOrEmpty_WhenTextParamIsInvalid_ShouldThrowNullReferenceException(string textParam)
        {
            // Act && Assert
            Assert.Throws<NullReferenceException>(() => Validator.CheckIfStringIsNullOrEmpty(textParam));
        }

        [Test]
        public void CheckIfStringIsNullOrEmpty_WhenTextParamIsValid_ShouldNotThrow()
        {
            // Arrange
            var exampleString = "20CharactersLongText";

            // Act && Assert
            Assert.DoesNotThrow(() => Validator.CheckIfStringIsNullOrEmpty(exampleString));
        }

        [TestCase(25, 25)]
        [TestCase(15, 25)]
        [TestCase(15, 5)]
        [TestCase(15, 0)]
        public void CheckIfStringLengthIsValid_WhenTextParamHasInvalidLenght_ShouldThrowIndexOutOfRangeException(int maxLenght, int minLenght)
        {
            // Arrange
            var exampleString = "20CharactersLongText";

            // Act && Assert
            Assert.Throws<IndexOutOfRangeException>(() => Validator.CheckIfStringLengthIsValid(exampleString, maxLenght, minLenght));
        }

        [TestCase(25, 20)]
        [TestCase(25, 15)]
        [TestCase(20, 20)]
        [TestCase(20, 0)]
        public void CheckIfStringLengthIsValid_WhenTextParamHasValidlenght_ShouldNotThrow(int maxLenght, int minLenght)
        {
            // Arrange
            var exampleString = "20CharactersLongText";

            // Act && Assert
            Assert.DoesNotThrow(() => Validator.CheckIfStringLengthIsValid(exampleString, maxLenght, minLenght));
        }
    }
}
