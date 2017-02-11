using Academy.Models;
using Academy.Models.Contracts;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Tests.Models.CourseTests
{
    [TestFixture]
    public class ToString_Should
    {
        [Test]
        public void IterateOverTheCollection_WhenTheCollectionIsNotEmpty()
        {
            // Arrange
            var courseUnderTest = new Course("Valid name", 5, new DateTime(2017, 10, 10), new DateTime(2017, 12, 10));

            var lectureMock = new Mock<ILecture>();

            lectureMock.Setup(x => x.ToString());
            courseUnderTest.Lectures.Add(lectureMock.Object);

            // Act
            courseUnderTest.ToString();

            // Assert
            lectureMock.Verify(x=>x.ToString(), Times.Once);
        }

        [Test]
        public void ReturnStringWithInformation_WhenTheCollectionIsEmpty()
        {
            // Arrange
            var courseUnderTest = new Course("Valid name", 5, new DateTime(2017, 10, 10), new DateTime(2017, 12, 10));

            // Act
            var result = courseUnderTest.ToString();

            // Assert
            StringAssert.Contains("no lectures", result);
        }
    }
}
