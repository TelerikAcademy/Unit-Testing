    using System;

using Moq;
using NUnit.Framework;
using PackageManager.Enums;
using PackageManager.Models;
using PackageManager.Models.Contracts;

namespace AcademyPackageManager.Tests.Models.PackageTests
{
    [TestFixture]
    public class Equals_Should
    {
        [Test]
        public void ThrowArgumentNullException_WhenTheObjectPassedIsNull()
        {
            // Arrange
            var versionMock = new Mock<IVersion>();

            var package = new Package("test", versionMock.Object);

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => package.Equals(null));
        }

        [Test]
        public void ThrowArgumentException_WhenTheObjectPassedIsNotIPackage()
        {
            // Arrange
            var versionMock = new Mock<IVersion>();

            var package = new Package("test", versionMock.Object);

            // Act & Assert
            Assert.Throws<ArgumentException>(() => package.Equals("not package"));
        }

        [Test]
        public void ReturnTrue_WhenThePackagesAreEqual()
        {
            // Arrange
            var versionMockPackageOne = new Mock<IVersion>();

            var packageOne = new Package("test", versionMockPackageOne.Object);

            versionMockPackageOne.SetupGet(x => x.Major).Returns(1);
            versionMockPackageOne.SetupGet(x => x.Minor).Returns(1);
            versionMockPackageOne.SetupGet(x => x.Patch).Returns(1);
            versionMockPackageOne.SetupGet(x => x.VersionType).Returns(VersionType.alpha);

            var versionMockPackageTwo = new Mock<IVersion>();

            versionMockPackageTwo.SetupGet(x => x.Major).Returns(1);
            versionMockPackageTwo.SetupGet(x => x.Minor).Returns(1);
            versionMockPackageTwo.SetupGet(x => x.Patch).Returns(1);
            versionMockPackageTwo.SetupGet(x => x.VersionType).Returns(VersionType.alpha);

            var packageTwo = new Package("test", versionMockPackageTwo.Object);

            // Act
            var result = packageOne.Equals(packageTwo);

            // Assert
            Assert.IsTrue(result);
        }

        [TestCase("not test", 1, 1, 1, VersionType.alpha)]
        [TestCase("test", 2, 1, 1, VersionType.alpha)]
        [TestCase("test", 1, 2, 1, VersionType.alpha)]
        [TestCase("test", 1, 1, 2, VersionType.alpha)]
        [TestCase("test", 1, 1, 1, VersionType.beta)]
        public void ReturnFalse_WhenThePackagesAreNotEqual(string name, int major, int minor, int patch, VersionType versionType)
        {
            // Arrange
            var versionMockPackageOne = new Mock<IVersion>();

            var packageOne = new Package(name, versionMockPackageOne.Object);

            versionMockPackageOne.SetupGet(x => x.Major).Returns(major);
            versionMockPackageOne.SetupGet(x => x.Minor).Returns(minor);
            versionMockPackageOne.SetupGet(x => x.Patch).Returns(patch);
            versionMockPackageOne.SetupGet(x => x.VersionType).Returns(versionType);

            var versionMockPackageTwo = new Mock<IVersion>();

            versionMockPackageTwo.SetupGet(x => x.Major).Returns(1);
            versionMockPackageTwo.SetupGet(x => x.Minor).Returns(1);
            versionMockPackageTwo.SetupGet(x => x.Patch).Returns(1);
            versionMockPackageTwo.SetupGet(x => x.VersionType).Returns(VersionType.alpha);

            var packageTwo = new Package("test", versionMockPackageTwo.Object);

            // Act
            var result = packageOne.Equals(packageTwo);

            // Assert
            Assert.IsFalse(result);
        }
    }
}
