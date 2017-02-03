using NUnit.Framework;
using System;
using Tasker.Models;

namespace Tasker.Tests.Models.TaskTests
{
    [TestFixture]
    public class IdTests
    {
        [TestCase(-1)]
        [TestCase(-10)]
        public void Id_ShouldThrowArgumentException_WhenPassedValueIsNegative(int value)
        {
            // Arrange
            var sut = new Task("Valid Description");

            // Act && Assert
            Assert.Throws<ArgumentException>(() => sut.Id = value);
        }

        [TestCase(1)]
        [TestCase(10)]
        public void Id_ShouldNotThrow_WhenPassedPositiveValue(int value)
        {
            // Arrange
            var sut = new Task("Valid Description");

            // Act && Assert
            Assert.DoesNotThrow(() => sut.Id = value);
        }

        [TestCase(1)]
        [TestCase(10)]
        public void Id_ShouldSetPassedValue_WhenPassedValueIsValid(int value)
        {
            // Arrange
            var sut = new Task("Valid Description");

            // Act
            sut.Id = value;

            // Assert
            Assert.AreEqual(value, sut.Id);
        }
    }
}
