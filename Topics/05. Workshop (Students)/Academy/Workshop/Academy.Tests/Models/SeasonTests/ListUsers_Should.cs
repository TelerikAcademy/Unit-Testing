using Academy.Models;
using Academy.Models.Contracts;
using Academy.Models.Enums;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.JustMock;
using Telerik.JustMock.Helpers;

namespace Academy.Tests.Models.SeasonTests
{
    [TestFixture]
    public class ListUsers_Should
    {

        [Test]
        public void IterateOverTheCollection_WhenTheCollectionIsNotEmpty()
        {
            // Arrange
            var season = new Season(2016, 2017, Initiative.KidsAcademy);

            var studentsMock = Mock.Create<Student>();
            Mock.Arrange(() => studentsMock.ToString()).OccursOnce();

            season.Students.Add(studentsMock);

            // Act
            var test = season.ListUsers();

            // Assert
            Mock.Assert(studentsMock);
        }

        [Test]
        public void IterateOverTheCollection_WhenTheCollectionIsNotEmpty_Moq()
        {
            // Arrange
            var season = new Season(2016, 2017, Initiative.KidsAcademy);

            var studentsMock = new Moq.Mock<IStudent>();

            studentsMock.Setup(x=>x.ToString()).Returns("");

            season.Students.Add(studentsMock.Object);

            // Act
            var test = season.ListUsers();

            // Assert
            studentsMock.Verify(x => x.ToString(), Moq.Times.Exactly(1));
        }
    }
}
