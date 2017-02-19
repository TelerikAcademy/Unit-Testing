using AcademyPackageManager.Tests.CustomExceptions;
using AcademyPackageManager.Tests.Repositories.Mocks;
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
    public class Add_Should
    {
        [Test]
        public void ThrowArgumentNullException_WhenThePackageIsNull()
        {
            // Arrange
            var loggerMock = new Mock<ILogger>();

            var repository = new PackageRepository(loggerMock.Object);

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => repository.Add(null));
        }

        [Test]
        public void AddAPackageAndCallLogger_WhenThePackageIsNotAlreadyAdded()
        {
            // Arrange
            var loggerMock = new Mock<ILogger>();
            var packageMock = new Mock<IPackage>();

            var repository = new PackageRepository(loggerMock.Object);

            // Act
            repository.Add(packageMock.Object);

            // Assert
            loggerMock.Verify(x => x.Log(It.IsAny<string>()), Times.Once);
        }

        [Test]
        public void PackageAlreadyExistMessageLogThreeTimes_WhenThePackageWithTheSameVersionIsAddedAlready()
        {
            // Arrange
            var loggerMock = new Mock<ILogger>();
            var packageMock = new Mock<IPackage>();
            packageMock.Setup(x => x.CompareTo(It.IsAny<IPackage>())).Returns(0);

            var collection = new List<IPackage>()
            {
                packageMock.Object
            };

            var repository = new PackageRepository(loggerMock.Object, collection);

            // Act
            repository.Add(packageMock.Object);

            // Assert
            loggerMock.Verify(x => x.Log(It.IsAny<string>()), Times.Exactly(3));
        }

        // The one with derived class
        [Test]
        public void CallUpdateMethod_WhenThePackageAddedAlreadyWithLowerVersion_WithException()
        {
            // Arrange
            var loggerMock = new Mock<ILogger>();
            var packageMock = new Mock<IPackage>();
            packageMock.Setup(x => x.CompareTo(It.IsAny<IPackage>())).Returns(1);

            var collection = new List<IPackage>()
            {
                packageMock.Object
            };

            var repository = new PackageRepositoryMock(loggerMock.Object, collection);

            // Act & Assert
            Assert.Throws<UpdateMethodCalledException>(() => repository.Add(packageMock.Object));
        }

        // The one with Moq
        [Test]
        public void CallUpdateMethod_WhenThePackageAddedAlreadyWithLowerVersion_WithCallBase()
        {
            // Arrange
            var loggerMock = new Mock<ILogger>();
            var packageMock = new Mock<IPackage>();
            packageMock.Setup(x => x.CompareTo(It.IsAny<IPackage>())).Returns(1);

            var collection = new List<IPackage>()
            {
                packageMock.Object
            };

            // Mocking system under test but using CallBase which will call the base implementation of the methods which are virtual
            // Therefore you should make the Add() method virtual in the PackageRepository class
            var repo = new Mock<PackageRepository>(loggerMock.Object, collection)
            {
                CallBase = true
            };

            var repository = new PackageRepository(loggerMock.Object, collection);

            repo.Object.Add(packageMock.Object);

            // Act & Assert
            // After this we are able to mock against the method calls 
            repo.Verify(x => x.Update(packageMock.Object), Times.Once);
        }

        [Test]
        public void PackageWithHigherVersionLogTwice_WhenThePackageAddedAlreadyWithHigherVersion()
        {
            // Arrange
            var loggerMock = new Mock<ILogger>();
            var packageMock = new Mock<IPackage>();
            packageMock.Setup(x => x.CompareTo(It.IsAny<IPackage>())).Returns(-1);

            var collection = new List<IPackage>()
            {
                packageMock.Object
            };

            var repository = new PackageRepository(loggerMock.Object, collection);

            // Act
            repository.Add(packageMock.Object);

            // Assert
            loggerMock.Verify(x => x.Log(It.IsAny<string>()), Times.Exactly(2));
        }
    }
}
