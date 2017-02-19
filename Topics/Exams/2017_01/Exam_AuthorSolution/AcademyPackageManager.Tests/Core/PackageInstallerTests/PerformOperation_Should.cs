using System;
using System.Collections.Generic;

using Moq;
using NUnit.Framework;
using PackageManager.Core;
using PackageManager.Core.Contracts;
using PackageManager.Enums;
using PackageManager.Models.Contracts;

namespace AcademyPackageManager.Tests.Core.PackageInstallerTests
{
    [TestFixture]
    public class PerformOperation_Should
    {
        [Test]
        public void InstallPackageWithoutDependencies_WhenPerformOperationIsCalledWithInstallOption()
        {
            // Arrange
            var downloaderMock = new Mock<IDownloader>();
            var projectMock = new Mock<IProject>();
            var packageMock = new Mock<IPackage>();

            projectMock.Setup(x => x.PackageRepository.GetAll()).Returns(new List<IPackage>());

            packageMock.Setup(x => x.Dependencies).Returns(new List<IPackage>());

            var installer = new PackageInstaller(downloaderMock.Object, projectMock.Object);

            installer.Operation = InstallerOperation.Install;

            // Act
            installer.PerformOperation(packageMock.Object);

            // Assert
            downloaderMock.Verify(x => x.Remove(It.IsAny<string>()), Times.Once);
            downloaderMock.Verify(x => x.Download(It.IsAny<string>()), Times.Exactly(2));
        }

        [Test]
        public void InstallPackageWithDependenciesCountEqualsOne_WhenPerformOperationIsCalledWithInstallOption()
        {
            // Arrange
            var downloaderMock = new Mock<IDownloader>();
            var projectMock = new Mock<IProject>();
            var packageMock = new Mock<IPackage>();
            var packageDependencyMock = new Mock<IPackage>();

            projectMock.Setup(x => x.PackageRepository.GetAll()).Returns(new List<IPackage>());

            packageDependencyMock.SetupGet(x => x.Dependencies).Returns(new List<IPackage>());

            packageMock.Setup(x => x.Dependencies).Returns(new List<IPackage>()
            {
                packageDependencyMock.Object
            });

            var installer = new PackageInstaller(downloaderMock.Object, projectMock.Object);

            installer.Operation = InstallerOperation.Install;

            // Act
            installer.PerformOperation(packageMock.Object);

            // Assert
            downloaderMock.Verify(x => x.Remove(It.IsAny<string>()), Times.Exactly(2));
            downloaderMock.Verify(x => x.Download(It.IsAny<string>()), Times.Exactly(4));
        }
    }
}
