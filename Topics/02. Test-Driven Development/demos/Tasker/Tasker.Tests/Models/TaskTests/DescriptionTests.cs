using NUnit.Framework;
using System;
using Tasker.Models;

namespace Tasker.Tests.Models.TaskTests
{
    [TestFixture]
    public class DescriptionTests
    {
        [TestCase(null)]
        [TestCase("")]
        [TestCase("     ")]
        public void Description_ShouldThrowArgumentNullException_WhenPassedNullOrEmptyValue(string value)
        {
            // Arrange
            var sut = new Task("Valid Description");

            // Act && Assert
            Assert.Throws<ArgumentNullException>(() => sut.Description = value);
        }
    }
}
