using Academy.Commands.Adding;
using Academy.Core.Contracts;
using Academy.Models;
using Academy.Models.Contracts;
using Academy.Models.Enums;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Tests.Commands.Adding.AddStudentToSeasonCommandTests
{
    [TestFixture]
    public class Execute_Should
    {
        [Test]
        public void ThrowArgumentException_WhenStudentIsAlreadyPartOfTheSeason()
        {
            // Arrange
            var factoryMock = new Mock<IAcademyFactory>();
            var engineMock = new Mock<IEngine>();

            var mockedStudent = new Mock<IStudent>();

            mockedStudent.SetupGet(x => x.Username).Returns("Pesho");

            engineMock.Setup(x => x.Students)
                                .Returns(new List<IStudent>() { mockedStudent.Object });

            var mockedSeason = new Mock<ISeason>();

            mockedSeason.Setup(x => x.Students)
                                .Returns(new List<IStudent>() { new Student("Pesho", Track.Dev) });

            engineMock.Setup(x => x.Seasons)
                .Returns(new List<ISeason>() { mockedSeason.Object });

            var command = new AddStudentToSeasonCommand(factoryMock.Object, engineMock.Object);

            // Act & Assert
            Assert.Throws<ArgumentException>(() => command.Execute(new List<string>() { "Pesho", "0" }));
        }

        [Test]
        public void AddCorrectlyStudent_WhenTheStudentIsNotInTheSeason()
        {
            // Arrange
            var factoryMock = new Mock<IAcademyFactory>();
            var engineMock = new Mock<IEngine>();

            var mockedStudent = new Mock<IStudent>();
            mockedStudent.SetupGet(x => x.Username).Returns("Pesho");

            engineMock.SetupGet(x => x.Students)
                                .Returns(new List<IStudent>() { mockedStudent.Object });

            var mockedSeason = new Mock<ISeason>();

            var mockedStudent1 = new Mock<IStudent>();
            mockedStudent1.SetupGet(x => x.Username).Returns("Not Pesho");

            mockedSeason.SetupGet(x => x.Students)
                     .Returns(new List<IStudent>() { mockedStudent1.Object });

            engineMock.Setup(x => x.Seasons)
                .Returns(new List<ISeason>() { mockedSeason.Object });

            var command = new AddStudentToSeasonCommand(factoryMock.Object, engineMock.Object);

            // Act
            command.Execute(new List<string>() { "Pesho", "0" });


            // Assert
            Assert.AreEqual(2, mockedSeason.Object.Students.Count());
        }


        [Test]
        public void ReturnMessageContainingStudentUsernameAndSeasonId_WhenTheStudentIsNotInTheSeason()
        {
            // Arrange
            var factoryMock = new Mock<IAcademyFactory>();
            var engineMock = new Mock<IEngine>();

            var mockedStudent = new Mock<IStudent>();
            mockedStudent.SetupGet(x => x.Username).Returns("Pesho");

            engineMock.SetupGet(x => x.Students)
                                .Returns(new List<IStudent>() { mockedStudent.Object });

            var mockedSeason = new Mock<ISeason>();

            var mockedStudent1 = new Mock<IStudent>();
            mockedStudent1.SetupGet(x => x.Username).Returns("Not Pesho");

            mockedSeason.SetupGet(x => x.Students)
                     .Returns(new List<IStudent>() { mockedStudent1.Object });

            engineMock.Setup(x => x.Seasons)
                .Returns(new List<ISeason>() { mockedSeason.Object });

            var command = new AddStudentToSeasonCommand(factoryMock.Object, engineMock.Object);

            // Act
            var result = command.Execute(new List<string>() { "Pesho", "0" });


            // Assert
            StringAssert.Contains("Pesho", result);
            StringAssert.Contains("0", result);
        }
    }
}
