using Academy.Core.Contracts;
using Academy.Commands.Adding;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Academy.Tests.Commands.Mocks;

namespace Academy.Tests.Commands.AddingTests.AddStudentToSeasonCommandTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ThrowArgumentNullException_WhenPassedFactoryIsNull()
        {
            // Arrange
            var engineMock = new Mock<IEngine>();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new AddStudentToSeasonCommand(null, engineMock.Object));
        }

        [Test]
        public void ThrowArgumentNullException_WhenPassedEngineIsNull()
        {
            // Arrange
            var factoryMock = new Mock<IAcademyFactory>();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new AddStudentToSeasonCommand(factoryMock.Object, null));
        }

        [Test]
        public void AssignCorrectValueToFactory_WhenPassedDependenciesAreNotNull()
        {
            // Arrange
            var factoryMock = new Mock<IAcademyFactory>();
            var engineMock = new Mock<IEngine>();

            // Act 
            var command = new AddStudentToSeasonCommandMock(factoryMock.Object, engineMock.Object);

            // Assert
            Assert.AreSame(factoryMock.Object, command.AcademyFactory);
        }

        [Test]
        public void AssignCorrectValueToEngine_WhenPassedDependenciesAreNotNull()
        {
            // Arrange
            var factoryMock = new Mock<IAcademyFactory>();
            var engineMock = new Mock<IEngine>();

            // Act 
            var command = new AddStudentToSeasonCommandMock(factoryMock.Object, engineMock.Object);

            // Assert
            Assert.AreSame(engineMock.Object, command.Engine);
        }
    }
}
