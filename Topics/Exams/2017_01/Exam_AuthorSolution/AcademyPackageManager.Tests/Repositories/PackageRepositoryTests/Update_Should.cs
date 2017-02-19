using Moq;
using NUnit.Framework;
using PackageManager.Info.Contracts;
using PackageManager.Models.Contracts;
using PackageManager.Repositories;
using System;
using System.Collections.Generic;

namespace AcademyPackageManager.Tests.Repositories.PackageRepositoryTests
{

    [TestFixture]
    public class Update_Should
    {
        [Test]
        public void ThrowArgumentNullException_WhenThePackageIsNull()
        {
            // Arrange
            var loggerMock = new Mock<ILogger>();

            var repository = new PackageRepository(loggerMock.Object);

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => repository.Update(null));
        }

        [Test]
        public void ThrowArgumentNullException_WhenThePackageIsNotFound()
        {
            // Arrange
            var loggerMock = new Mock<ILogger>();
            var packageMock = new Mock<IPackage>();

            var repository = new PackageRepository(loggerMock.Object);

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => repository.Update(packageMock.Object));
            loggerMock.Verify(x => x.Log(It.IsAny<string>()), Times.Once);
        }

        [Test]
        public void ReturnsTrueAndUpdatePackage_WhenThePackageIsFoundWithLowerVersion()
        {
            // Arrange
            var loggerMock = new Mock<ILogger>();
            var packageMock = new Mock<IPackage>();

            packageMock.Setup(x => x.CompareTo(It.IsAny<IPackage>())).Returns(1);

            packageMock.Setup(x => x.Name).Returns("test");

            var packageMockAddedToCollection = new Mock<IPackage>();

            packageMockAddedToCollection.Setup(x => x.Name).Returns("test");

            var collection = new List<IPackage>()
            {
                packageMockAddedToCollection.Object
            };

            var repository = new PackageRepository(loggerMock.Object, collection);

            // Act
            var result = repository.Update(packageMock.Object);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void ThrowArgumentException_WhenThePackageIsFoundWithHigherVersion()
        {
            // Arrange
            var loggerMock = new Mock<ILogger>();
            var packageMock = new Mock<IPackage>();

            packageMock.Setup(x => x.CompareTo(It.IsAny<IPackage>())).Returns(-1);

            packageMock.Setup(x => x.Name).Returns("test");

            var packageMockAddedToCollection = new Mock<IPackage>();

            packageMockAddedToCollection.Setup(x => x.Name).Returns("test");

            var collection = new List<IPackage>()
            {
                packageMockAddedToCollection.Object
            };

            var repository = new PackageRepository(loggerMock.Object, collection);

            // Act & Assert
            Assert.Throws<ArgumentException>(() => repository.Update(packageMock.Object));
            loggerMock.Verify(x => x.Log(It.IsAny<string>()), Times.Once);
        }

        [Test]
        public void ReturnsFalseAndUpdatePackage_WhenThePackageIsFoundWithTheSameVersion()
        {
            // Arrange
            var loggerMock = new Mock<ILogger>();
            var packageMock = new Mock<IPackage>();

            packageMock.Setup(x => x.CompareTo(It.IsAny<IPackage>())).Returns(0);

            packageMock.Setup(x => x.Name).Returns("test");

            var packageMockAddedToCollection = new Mock<IPackage>();

            packageMockAddedToCollection.Setup(x => x.Name).Returns("test");

            var collection = new List<IPackage>()
            {
                packageMockAddedToCollection.Object
            };

            var repository = new PackageRepository(loggerMock.Object, collection);

            // Act
            var result = repository.Update(packageMock.Object);

            // Assert
            Assert.IsFalse(result);
        }
    }
}
