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
    public class Constructor_Should
    {
        [Test]
        public void CorrectlyAssignCourseName_WhenTheObjectIsConstructed()
        {
            // Arrange & Act
            var courseUnderTest = new Course("Valid name", 5, new DateTime(2017, 10, 10), new DateTime(2017, 12, 10));

            // Assert
            Assert.AreEqual("Valid name", courseUnderTest.Name);
        }

        [Test]
        public void CorrectlyAssignCourseLecturesPerWeek_WhenTheObjectIsConstructed()
        {
            // Arrange & Act
            var courseUnderTest = new Course("Valid name", 5, new DateTime(2017, 10, 10), new DateTime(2017, 12, 10));

            // Assert
            Assert.AreEqual(5, courseUnderTest.LecturesPerWeek);
        }

        [Test]
        public void CorrectlyAssignCourseStartingDate_WhenTheObjectIsConstructed()
        {
            // Arrange & Act
            var courseUnderTest = new Course("Valid name", 5, new DateTime(2017, 10, 10), new DateTime(2017, 12, 10));

            // Assert
            Assert.AreEqual(new DateTime(2017,10,10), courseUnderTest.StartingDate);
        }

        [Test]
        public void CorrectlyAssignCourseEndingDate_WhenTheObjectIsConstructed()
        {
            // Arrange & Act
            var courseUnderTest = new Course("Valid name", 5, new DateTime(2017, 10, 10), new DateTime(2017, 12, 10));

            // Assert
            Assert.AreEqual(new DateTime(2017, 12, 10), courseUnderTest.EndingDate);
        }

        [Test]
        public void CorrectlyInitializeOnlineStudentsCollection_WhenTheObjectIsConstructed()
        {
            // Arrange & Act
            var courseUnderTest = new Course("Valid name", 5, new DateTime(2017, 10, 10), new DateTime(2017, 12, 10));

            // Assert
            Assert.IsInstanceOf(typeof(IEnumerable<IStudent>), courseUnderTest.OnlineStudents);
        }

        [Test]
        public void CorrectlyInitializeOnsiteStudentsCollection_WhenTheObjectIsConstructed()
        {
            // Arrange & Act
            var courseUnderTest = new Course("Valid name", 5, new DateTime(2017, 10, 10), new DateTime(2017, 12, 10));

            // Assert
            Assert.IsInstanceOf(typeof(IEnumerable<IStudent>), courseUnderTest.OnsiteStudents);
        }

        [Test]
        public void CorrectlyInitializeLecturesCollection_WhenTheObjectIsConstructed()
        {
            // Arrange & Act
            var courseUnderTest = new Course("Valid name", 5, new DateTime(2017, 10, 10), new DateTime(2017, 12, 10));

            // Assert
            Assert.IsInstanceOf(typeof(IEnumerable<ILecture>), courseUnderTest.Lectures);
        }
    }
}
