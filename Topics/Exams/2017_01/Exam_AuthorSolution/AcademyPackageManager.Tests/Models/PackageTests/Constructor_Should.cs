using Moq;
using NUnit.Framework;
using PackageManager.Enums;
using PackageManager.Models;
using PackageManager.Models.Contracts;
using System;
using System.Collections.Generic;

namespace AcademyPackageManager.Tests.Models.PackageTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ReturnInstanceOfPackageClass_WhenValidValuesArePassed()
        {
            // Arrange & Act
            var versionMock = new Mock<IVersion>();
            var package = new Package("name", versionMock.Object);

            // Assert
            Assert.IsInstanceOf<Package>(package);
        }

        [Test]
        public void ThrowArgumentNullException_WhenThePassedNameIsNull()
        {
            // Arrange
            var versionMock = new Mock<IVersion>();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new Package(null, versionMock.Object, null));
        }

        [Test]
        public void ThrowArgumentNullException_WhenThePassedVersionIsNull()
        {
            // Arrange & Act & Assert
            Assert.Throws<ArgumentNullException>(() => new Package("test", null, null));
        }

        [Test]
        public void SetEmptyCollectionOfDependencies_WhenNoArgumentForDependenciesIsPassed()
        {
            // Arrange & Act
            var versionMock = new Mock<IVersion>();
            var package = new Package("test", versionMock.Object);

            // Assert
            Assert.AreEqual(0, package.Dependencies.Count);
        }

        [Test]
        public void SetTheProperCollectionOfDependencies_WhenDependenciesIsPassed()
        {
            // Arrange
            var versionMock = new Mock<IVersion>();

            var dependencies = new List<IPackage>();

            // Act
            var package = new Package("test", versionMock.Object, dependencies);

            // Assert
            Assert.AreSame(dependencies, package.Dependencies);
        }

        [Test]
        public void SetTheProperName_WhenTheObjectIsConstructed()
        {
            // Arrange & Act
            var versionMock = new Mock<IVersion>();

            var package = new Package("test", versionMock.Object);

            // Assert
            Assert.AreEqual("test", package.Name);
        }

        [Test]
        public void SetTheProperVersion_WhenTheObjectIsConstructed()
        {
            // Arrange
            var versionMock = new Mock<IVersion>();

            // Act
            var package = new Package("test", versionMock.Object);

            // Assert
            Assert.AreSame(versionMock.Object, package.Version);
        }

        [Test]
        public void SetTheProperUrl_WhenTheObjectIsConstructed()
        {
            // Arrange & Act
            var versionMock = new Mock<IVersion>();

            versionMock.SetupGet(x => x.Major).Returns(1);
            versionMock.SetupGet(x => x.Minor).Returns(1);
            versionMock.SetupGet(x => x.Patch).Returns(1);
            versionMock.SetupGet(x => x.VersionType).Returns(VersionType.alpha);

            // Act
            var package = new Package("test", versionMock.Object);

            // Assert
            Assert.AreEqual("1.1.1-alpha", package.Url);
        }
    }
}
