using Academy.Commands.Adding;
using Academy.Core.Contracts;
using Academy.Models;
using Academy.Models.Contracts;
using Academy.Models.Enums;
using Academy.Models.Utils;
using Academy.Models.Utils.Contracts;
using Moq;
using NUnit.Framework;
using Ploeh.AutoFixture;
using Ploeh.AutoFixture.Kernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Tests.Commands.Adding.AddStudentToCourseCommandTests
{
    [TestFixture]
    public class Execute_Should
    {
        [Test]
        public void AddCorrectlyOnlineStudents_WhenTheParametersAreOk()
        {
            // Arrange
            var factoryMock = new Mock<IAcademyFactory>();
            var engineMock = new Mock<IEngine>();

            var mockedStudent = new Mock<IStudent>();

            mockedStudent.SetupGet(x => x.Username).Returns("Pesho");

            engineMock.Setup(x => x.Students)
                                .Returns(new List<IStudent>() { mockedStudent.Object });

            var mockedSeason = new Mock<ISeason>();

            var mockedCourse = new Mock<ICourse>();

            mockedCourse.Setup(x => x.OnlineStudents).Returns(new List<IStudent>());
            mockedCourse.Setup(x => x.OnsiteStudents).Returns(new List<IStudent>());

            mockedSeason.Setup(x => x.Courses)
                                .Returns(new List<ICourse>() { mockedCourse.Object });

            engineMock.Setup(x => x.Seasons)
                .Returns(new List<ISeason>() { mockedSeason.Object });

            var command = new AddStudentToCourseCommand(factoryMock.Object, engineMock.Object);

            // Act & Assert
            var result = command.Execute(new List<string>() { "Pesho", "0", "0", "online" });

            Assert.AreEqual(1, mockedCourse.Object.OnlineStudents.Count);
        }

        [Test]
        public void AddCorrectlyOnsiteStudents_WhenTheParametersAreOk()
        {
            // Arrange
            var factoryMock = new Mock<IAcademyFactory>();
            var engineMock = new Mock<IEngine>();
            var fixture = new Fixture();

            fixture.Register<string>(()=>"Pesho");
            fixture.Register<int>(()=>5);
            fixture.Register<float>(()=>5f);
            fixture.Customizations.Add(new TypeRelay(typeof(ICourseResult), typeof(CourseResult)));
            fixture.Customizations.Add(new TypeRelay(typeof(ICourse), typeof(Course)));

            var studentStub = fixture.Create<Student>();


            
            engineMock.Setup(x => x.Students)
                                .Returns(new List<IStudent>() { studentStub });

            var mockedSeason = new Mock<ISeason>();

            var mockedCourse = new Mock<ICourse>();

            mockedCourse.Setup(x => x.OnlineStudents).Returns(new List<IStudent>());
            mockedCourse.Setup(x => x.OnsiteStudents).Returns(new List<IStudent>());

            mockedSeason.Setup(x => x.Courses)
                                .Returns(new List<ICourse>() { mockedCourse.Object });

            engineMock.Setup(x => x.Seasons)
                .Returns(new List<ISeason>() { mockedSeason.Object });

            var command = new AddStudentToCourseCommand(factoryMock.Object, engineMock.Object);

            // Act & Assert
            var result = command.Execute(new List<string>() { "Pesho", "0", "0", "onsite" });

            Assert.AreEqual(1, mockedCourse.Object.OnsiteStudents.Count);
        }


        [Test]
        public void ThrowArgumentException_WhenTheFormOfEducationIsNotAvailable()
        {
            // Arrange
            var factoryMock = new Mock<IAcademyFactory>();
            var engineMock = new Mock<IEngine>();

            var mockedStudent = new Mock<IStudent>();

            mockedStudent.SetupGet(x => x.Username).Returns("Pesho");

            engineMock.Setup(x => x.Students)
                                .Returns(new List<IStudent>() { mockedStudent.Object });

            var mockedSeason = new Mock<ISeason>();

            var mockedCourse = new Mock<ICourse>();

            mockedCourse.Setup(x => x.OnlineStudents).Returns(new List<IStudent>());
            mockedCourse.Setup(x => x.OnsiteStudents).Returns(new List<IStudent>());

            mockedSeason.Setup(x => x.Courses)
                                .Returns(new List<ICourse>() { mockedCourse.Object });

            engineMock.Setup(x => x.Seasons)
                .Returns(new List<ISeason>() { mockedSeason.Object });

            var command = new AddStudentToCourseCommand(factoryMock.Object, engineMock.Object);

            // Act & Assert

            Assert.Throws<ArgumentException>(() => command.Execute(new List<string>() { "Pesho", "0", "0", "on and on" }));
        }
    }
}
