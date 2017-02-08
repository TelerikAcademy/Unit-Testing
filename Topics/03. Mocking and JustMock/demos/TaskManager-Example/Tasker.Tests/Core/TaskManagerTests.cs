using NUnit.Framework;
using System;
using System.IO;
using Tasker.Core;
using Tasker.Core.Contracts;
using Tasker.Models;
using Tasker.Models.Contracts;
using Tasker.Tests.Core.Fakes;
using Telerik.JustMock;

namespace Tasker.Tests.Core
{
    [TestFixture]
    public class TaskManagerTests
    {
        [Test]
        public void Add_ShouldLogSuccessfulMessage_WhenPassedValidTask()
        {
            // Arrange
            //var loggerMock = new Mock<ILogger>();
            //var idProviderStub = new Mock<IIdProvider>();
            //var taskStub = new Mock<ITask>();

            var loggerMock = Mock.Create<ILogger>();
            var idProviderStub = Mock.Create<IIdProvider>();
            var taskStub = Mock.Create<ITask>();

            var manager = new TaskManager(idProviderStub, loggerMock);
            var list = new List();

            Mock.Arrange(() => idProviderStub.NextId()).Returns(0);
            idProviderStub.Setup(x => x.NextId()).Return(0);

            // Act
            manager.Add(taskStub);

            // Assert
            //loggerMock.Verify(x => x.Log(It.IsAny<string>()), Times.Exactly(1));
            Mock.Assert(() => loggerMock.Log(Arg.AnyString), Occurs.Once());
        }
    }
}
