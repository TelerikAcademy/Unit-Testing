using Academy.Commands.Adding;
using Academy.Core.Contracts;
using Academy.Models;
using Academy.Models.Contracts;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Tests.Commands.Adding.AddingToSeasonCommandTests
{
    [TestFixture]
    public class Execute_Should
    {
        [Test]
        public void ThrowsArgumentException_WhenTheStudentIsAlreadyInTheSeason()
        {
            // Arrange
            var factoryMock = new Mock<IAcademyFactory>();
            var engineMock = new Mock<IEngine>();

            var studentMock = new Mock<IStudent>();

            studentMock.SetupGet(x => x.Username).Returns("Pesho");

            engineMock.SetupGet(x => x.Students).Returns(new List<IStudent>() { studentMock.Object });

            var seasonMock = new Mock<ISeason>();


            seasonMock.SetupGet(x => x.Students).Returns(new List<IStudent>() { studentMock.Object });

            engineMock.SetupGet(x => x.Seasons).Returns(new List<ISeason>() { seasonMock.Object });


            var command = new AddStudentToSeasonCommand(factoryMock.Object, engineMock.Object);

            // Act & Assert
            Assert.Throws<ArgumentException>(() => command.Execute(new List<string>() { "Pesho", "0" }));
        }


        [Test]
        public void AddStudentToCollection_WhenTheStudentIsNotInTheSeason()
        {
            // Arrange
            var factoryMock = new Mock<IAcademyFactory>();
            var engineMock = new Mock<IEngine>();

            var studentMock = new Mock<IStudent>();

            studentMock.SetupGet(x => x.Username).Returns("Pesho");

            engineMock.SetupGet(x => x.Students).Returns(new List<IStudent>() { studentMock.Object });

            var seasonMock = new Mock<ISeason>();

            var studentMockNoPesho = new Mock<IStudent>();

            studentMockNoPesho.SetupGet(x => x.Username).Returns("Not Pesho");

            var studentsInSeason = new List<IStudent>() { studentMockNoPesho.Object };

            seasonMock.SetupGet(x => x.Students).Returns(studentsInSeason);

            engineMock.SetupGet(x => x.Seasons).Returns(new List<ISeason>() { seasonMock.Object });


            var command = new AddStudentToSeasonCommand(factoryMock.Object, engineMock.Object);

            // Act 
            var result = command.Execute(new List<string>() { "Pesho", "0" });

            //Assert
            Assert.AreEqual(2, seasonMock.Object.Students.Count);
        }

        [Test]
        public void ReturnMessage_WhenTheStudentIsAddedToCollection()
        {
            // Arrange
            var factoryMock = new Mock<IAcademyFactory>();
            var engineMock = new Mock<IEngine>();

            var studentMock = new Mock<IStudent>();

            studentMock.SetupGet(x => x.Username).Returns("Pesho");

            engineMock.SetupGet(x => x.Students).Returns(new List<IStudent>() { studentMock.Object });

            var seasonMock = new Mock<ISeason>();


            var studentMockNoPesho = new Mock<IStudent>();

            studentMockNoPesho.SetupGet(x => x.Username).Returns("Not Pesho");

            var studentsInSeason = new List<IStudent>() { studentMockNoPesho.Object };

            seasonMock.SetupGet(x => x.Students).Returns(studentsInSeason);

            engineMock.SetupGet(x => x.Seasons).Returns(new List<ISeason>() { seasonMock.Object });


            var command = new AddStudentToSeasonCommand(factoryMock.Object, engineMock.Object);

            // Act 
            var result = command.Execute(new List<string>() { "Pesho", "0" });

            //Assert
            StringAssert.Contains("Pesho", result);
            StringAssert.Contains("Season 0", result);
        }
    }
}
