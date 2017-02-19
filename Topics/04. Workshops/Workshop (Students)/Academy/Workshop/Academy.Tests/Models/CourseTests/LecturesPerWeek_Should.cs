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
    public class LecturesPerWeek_Should
    {
        [Test]
        public void ReturnTheCorrectValue_WhenCalledWithGetMethod()
        {
            // Arrange & Act
            var courseUnderTest = new Course("Valid name", 5, new DateTime(2017, 10, 10), new DateTime(2017, 12, 10));

            // Assert
            Assert.AreEqual(5, courseUnderTest.LecturesPerWeek);
        }

        [TestCase(0)]
        [TestCase(8)]
        public void ThrowsArgumentException_WhenInvalidValueIsPassed(int lecturesPerWeek)
        {
            // Arrange
            Course courseUnderTest = courseUnderTest = new Course("Valid name", 5, new DateTime(2017, 10, 10), new DateTime(2017, 12, 10));

            // Act && Assert
            Assert.Throws<ArgumentException>(() => courseUnderTest.LecturesPerWeek = lecturesPerWeek);
        }

        [Test]
        public void SetTheDesiredName_WhenValidValueIsPassed()
        {
            // Arrange
            Course courseUnderTest = courseUnderTest = new Course("Valid name", 5, new DateTime(2017, 10, 10), new DateTime(2017, 12, 10));

            // Act
            courseUnderTest.LecturesPerWeek = 3;

            // Assert
            Assert.AreEqual(3, courseUnderTest.LecturesPerWeek);
        }
    }
}
