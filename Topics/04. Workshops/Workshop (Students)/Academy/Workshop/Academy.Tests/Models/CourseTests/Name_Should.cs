using Academy.Models;
using Academy.Models.Contracts;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Tests.Models.CourseTests
{
    [TestFixture]
    public class Name_Should
    {
        [Test]
        public void ReturnTheCorrectValue_WhenCalledWithGetMethod()
        {
            // Arrange & Act
            var courseUnderTest = new Course("Valid name", 5, new DateTime(2017, 10, 10), new DateTime(2017, 12, 10));

            // Assert
            Assert.AreEqual("Valid name", courseUnderTest.Name);
        }


        [TestCase("I")]
        [TestCase("Very Very Very Very Very Very Very Very Very Very Long Name")]
        public void ThrowsArgumentException_WhenInvalidValueIsPassed(string name)
        {
            // Arrange
            Course courseUnderTest = courseUnderTest = new Course("Valid name", 5, new DateTime(2017, 10, 10), new DateTime(2017, 12, 10));

            // Act && Assert
            Assert.Throws<ArgumentException>(() => courseUnderTest.Name = name);
        }

        [Test]
        public void SetTheDesiredName_WhenValidValueIsPassed()
        {
            // Arrange
            Course courseUnderTest = courseUnderTest = new Course("Valid name", 5, new DateTime(2017, 10, 10), new DateTime(2017, 12, 10));

            // Act
            courseUnderTest.Name = "Changed valid name";

            // Assert
            Assert.AreEqual("Changed valid name", courseUnderTest.Name);
        }
    }
}
