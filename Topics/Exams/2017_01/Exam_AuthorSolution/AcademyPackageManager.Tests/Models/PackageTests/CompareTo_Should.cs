using Moq;
using NUnit.Framework;
using PackageManager.Enums;
using PackageManager.Models;
using PackageManager.Models.Contracts;
using System;

namespace AcademyPackageManager.Tests.Models.PackageTests
{
    [TestFixture]
    public class CompareTo_Should
    {
        [Test]
        public void ThrowArgumentNullException_WhenThePackageToCompareToIsNull()
        {
            // Arrange
            var versionMock = new Mock<IVersion>();

            var package = new Package("test", versionMock.Object);

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => package.CompareTo(null));
        }

        [Test]
        public void ThrowArgumentException_WhenThePackageAreNotWithTheSameName()
        {
            // Arrange
            var versionMock = new Mock<IVersion>();

            var packageOne = new Package("test", versionMock.Object);

            var packageTwo = new Package("not test", versionMock.Object);

            // Act & Assert
            Assert.Throws<ArgumentException>(() => packageOne.CompareTo(packageTwo));
        }

        [Test]
        public void ReturnZero_WhenThePackagesAreTheSameVersion()
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
            var result = packageOne.CompareTo(packageTwo);

            // Assert
            Assert.AreEqual(0, result);
        }

        [TestCase(1, 1, 1, VersionType.beta)]
        [TestCase(1, 1, 2, VersionType.alpha)]
        [TestCase(1, 2, 1, VersionType.alpha)]
        [TestCase(2, 1, 1, VersionType.alpha)]
        [TestCase(2, 2, 2, VersionType.beta)]
        public void ReturnOne_WhenThePackagePassedIsWithOlderVersion(int major, int minor, int patch, VersionType versionType)
        {
            // Arrange
            var versionMockPackageOne = new Mock<IVersion>();

            var packageOne = new Package("test", versionMockPackageOne.Object);

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
            var result = packageOne.CompareTo(packageTwo);

            // Assert
            Assert.AreEqual(1, result);
        }

        [TestCase(1, 1, 1, VersionType.beta)]
        [TestCase(1, 1, 2, VersionType.alpha)]
        [TestCase(1, 2, 1, VersionType.alpha)]
        [TestCase(2, 1, 1, VersionType.alpha)]
        [TestCase(2, 2, 2, VersionType.beta)]
        public void ReturnMinusOne_WhenThePackagePassedIsWithNewerVersion(int major, int minor, int patch, VersionType versionType)
        {
            // Arrange
            var versionMockPackageOne = new Mock<IVersion>();

            var packageOne = new Package("test", versionMockPackageOne.Object);

            versionMockPackageOne.SetupGet(x => x.Major).Returns(1);
            versionMockPackageOne.SetupGet(x => x.Minor).Returns(1);
            versionMockPackageOne.SetupGet(x => x.Patch).Returns(1);
            versionMockPackageOne.SetupGet(x => x.VersionType).Returns(VersionType.alpha);

            var versionMockPackageTwo = new Mock<IVersion>();

            versionMockPackageTwo.SetupGet(x => x.Major).Returns(major);
            versionMockPackageTwo.SetupGet(x => x.Minor).Returns(minor);
            versionMockPackageTwo.SetupGet(x => x.Patch).Returns(patch);
            versionMockPackageTwo.SetupGet(x => x.VersionType).Returns(versionType);

            var packageTwo = new Package("test", versionMockPackageTwo.Object);

            // Act
            var result = packageOne.CompareTo(packageTwo);

            // Assert
            Assert.AreEqual(-1, result);
        }
    }
}
