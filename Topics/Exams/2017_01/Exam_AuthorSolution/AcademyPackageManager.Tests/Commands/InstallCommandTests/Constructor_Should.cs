using System;

using AcademyPackageManager.Tests.Commands.Mocks;
using Moq;
using NUnit.Framework;
using PackageManager.Commands;
using PackageManager.Core.Contracts;
using PackageManager.Enums;
using PackageManager.Models.Contracts;

namespace AcademyPackageManager.Tests.Commands.InstallCommandTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ReturnInstanceOfInstallCommandClass_WhenThePassedValuesAreValid()
        {
            // Arrange & Act
            var packageMock = new Mock<IPackage>();
            var installerMock = new Mock<IInstaller<IPackage>>();
            var command = new InstallCommand(installerMock.Object, packageMock.Object);

            // Assert
            Assert.IsInstanceOf<InstallCommand>(command);
        }

        [Test]
        public void ThrowArgumentNullException_WhenThePassedInstallerIsNull()
        {
            // Arrange
            var packageMock = new Mock<IPackage>();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new InstallCommand(null, packageMock.Object));
        }

        [Test]
        public void ThrowArgumentNullException_WhenThePassedPackageIsNull()
        {
            // Arrange
            var installerMock = new Mock<IInstaller<IPackage>>();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new InstallCommand(installerMock.Object, null));
        }

        [Test]
        public void SetInstaller_WhenConstructingTheObject()
        {
            // Arrange
            var installerMock = new Mock<IInstaller<IPackage>>();
            var packageMock = new Mock<IPackage>();

            // Act
            var command = new InstallCommandMock(installerMock.Object, packageMock.Object);

            // Assert
            Assert.AreSame(installerMock.Object, command.MyInstaller);
        }

        [Test]
        public void SetPackage_WhenConstructingTheObject()
        {
            // Arrange
            var installerMock = new Mock<IInstaller<IPackage>>();
            var packageMock = new Mock<IPackage>();

            // Act
            var command = new InstallCommandMock(installerMock.Object, packageMock.Object);

            // Assert
            Assert.AreSame(packageMock.Object, command.MyPackage);
        }

        [Test]
        public void SetOperationTypeToInstall_WhenConstructingTheObject()
        {
            // Arrange
            var installerMock = new Mock<IInstaller<IPackage>>();
            var packageMock = new Mock<IPackage>();

            // Act
            var command = new InstallCommandMock(installerMock.Object, packageMock.Object);

            // Assert
            Assert.AreEqual(InstallerOperation.Install, installerMock.Object.Operation);
        }
    }
}
