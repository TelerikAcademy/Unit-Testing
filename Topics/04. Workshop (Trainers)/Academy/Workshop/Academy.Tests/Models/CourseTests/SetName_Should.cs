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
    public class SetName_Should
    {
        [TestCase("i")]
        [TestCase("very very very very very very very very very very very very very very very very long string")]
        public void ThrowsArgumentException_WhenInvalidValueIsPassed(string name)
        {
            // Arrange
            var course = new Course("Valid name", 5, new DateTime(2017, 02, 10), new DateTime(2017, 03, 10));

            // Act && Assert
            Assert.Throws<ArgumentException>(() => course.Name = name);
        }
    }
}
