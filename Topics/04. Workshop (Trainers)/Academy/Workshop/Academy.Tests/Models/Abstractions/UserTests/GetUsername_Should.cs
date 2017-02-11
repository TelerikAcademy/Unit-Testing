using Academy.Models.Abstractions;
using Academy.Tests.Models.Abstractions.Mocks;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Tests.Models.Abstractions.UserTests
{
    [TestFixture]
    public class GetUsername_Should
    {
        [Test]
        public void ReturnProperUsername_WhenTheGetMethodISCalled()
        {
            // Arrange
            var user = new UserMock("Pesho");

            // Act
            var foundUsername = user.Username;

            // Assert
            Assert.AreEqual("Pesho", foundUsername);
        }
    }
}
