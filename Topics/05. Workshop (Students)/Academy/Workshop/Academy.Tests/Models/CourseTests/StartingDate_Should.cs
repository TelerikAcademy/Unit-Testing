using Academy.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Tests.Models.CourseTests
{
    [TestFixture]
    public class StartingDate_Should
    {
        [Test]
        public void ReturnTheCorrectValue_WhenCalledWithGetMethod()
        {
            // Arrange & Act
            var courseUnderTest = new Course("Valid name", 5, new DateTime(2017, 10, 10), new DateTime(2017, 12, 10));

            // Assert
            Assert.AreEqual(new DateTime(2017, 10, 10), courseUnderTest.StartingDate);
        }


        [Test]
        public void ThrowsArgumentException_WhenInvalidValueIsPassed()
        {
            // Arrange
            Course courseUnderTest = courseUnderTest = new Course("Valid name", 5, new DateTime(2017, 10, 10), new DateTime(2017, 12, 10));

            // Act && Assert
            Assert.Throws<ArgumentNullException>(() => courseUnderTest.StartingDate = null);
        }

        [Test]
        public void SetTheDesiredName_WhenValidValueIsPassed()
        {
            // Arrange
            Course courseUnderTest = courseUnderTest = new Course("Valid name", 5, new DateTime(2017, 10, 10), new DateTime(2017, 12, 10));

            // Act
            courseUnderTest.StartingDate = new DateTime(2017, 9, 9);

            // Assert
            Assert.AreEqual(new DateTime(2017, 9, 9), courseUnderTest.StartingDate);
        }
    }
}
