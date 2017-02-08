using NUnit.Framework;
using Tasker.Models;

namespace Tasker.Tests.Models.TaskTests
{
    [TestFixture]
    public class CtorTests
    {
        public void Ctor_ShouldAssignDescription_WhenInvoked()
        {
            // Arrange && Act
            var expected = "Valid Description";
            var sut = new Task(expected);

            // Assert
            Assert.AreEqual(expected, sut.Description);
        }
    }
}
