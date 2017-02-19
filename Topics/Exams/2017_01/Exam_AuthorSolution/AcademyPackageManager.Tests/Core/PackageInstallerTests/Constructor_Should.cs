using System.Collections.Generic;

using AcademyPackageManager.Tests.Core.PackageInstallerTests.Mocks;
using Moq;
using NUnit.Framework;
using PackageManager.Core.Contracts;
using PackageManager.Models.Contracts;
using PackageManager.Core;

namespace AcademyPackageManager.Tests.Core.PackageInstallerTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void RestorePackges_WhenObjectIsConstructed()
        {
            // Arrange
            var downloaderMock = new Mock<IDownloader>();
            var projectMock = new Mock<IProject>();

            var packageMock = new Mock<IPackage>();

            projectMock.Setup(x => x.PackageRepository.GetAll()).Returns(new List<IPackage>()
            {
                packageMock.Object,
                packageMock.Object
            });

            // Act
            var installer = new PackageInstallerMock(downloaderMock.Object, projectMock.Object);

            // Assert
            Assert.AreEqual(2, installer.Counter);
        }

        [Test]
        public void RestorePackges_WhenObjectIsConstructed_Moq()
        {
            // Arrange
            var downloaderMock = new Mock<IDownloader>();
            var projectMock = new Mock<IProject>();

            var packageMock = new Mock<IPackage>();

            projectMock.Setup(x => x.PackageRepository.GetAll()).Returns(new List<IPackage>()
            {
                packageMock.Object,
                packageMock.Object
            });

            // Mocking the SUT but with behaviour CallBase = true
            var installer = new Mock<PackageInstaller>(downloaderMock.Object, projectMock.Object)
            {
                CallBase = true
            };

            installer.Setup(x => x.PerformOperation(It.IsAny<IPackage>()));

            // Act
            var installerObject = installer.Object;


            // Assert
            installer.Verify(x => x.PerformOperation(It.IsAny<IPackage>()), Times.Exactly(2));
        }
    }
}
