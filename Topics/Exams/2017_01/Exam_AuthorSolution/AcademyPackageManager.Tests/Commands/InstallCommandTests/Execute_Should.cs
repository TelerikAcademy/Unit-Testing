using Moq;
using NUnit.Framework;
using PackageManager.Commands;
using PackageManager.Core.Contracts;
using PackageManager.Models.Contracts;

namespace AcademyPackageManager.Tests.Commands.InstallCommandTests
{
    [TestFixture]
    public class Execute_Should
    {
        [Test]
        public void CallPerformOperationFromInstaller_WhenTheCommandIsExecuted()
        {
            // Arrange
            var installerMock = new Mock<IInstaller<IPackage>>();
            var packageMock = new Mock<IPackage>();

            var command =  new InstallCommand(installerMock.Object, packageMock.Object);

            // Act
            command.Execute();

            // Assert
            installerMock.Verify(x => x.PerformOperation(packageMock.Object), Times.Once);
        }
    }
}
