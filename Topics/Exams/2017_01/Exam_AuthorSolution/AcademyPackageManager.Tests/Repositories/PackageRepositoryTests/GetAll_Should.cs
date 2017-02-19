using Moq;
using NUnit.Framework;
using PackageManager.Info.Contracts;
using PackageManager.Models.Contracts;
using PackageManager.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace AcademyPackageManager.Tests.Repositories.PackageRepositoryTests
{
    [TestFixture]
    public class GetAll_Should
    {
        [Test]
        public void ReturnsEmptyCollection_WhenTheCollectionIsNotPassed()
        {
            // Arrange
            var loggerMock = new Mock<ILogger>();
            var coll = new List<IPackage>();

            var repository = new PackageRepository(loggerMock.Object);

            // Act
            var packagesFound = repository.GetAll();

            // Assert
            Assert.AreEqual(0, packagesFound.Count());
        }

        [Test]
        public void ReturnsCollectionWithNumberOfElementsPassed_WhenTheCollectionPassedIsNotEmpty()
        {
            // Arrange
            var loggerMock = new Mock<ILogger>();
            var packageMock = new Mock<IPackage>();

            var coll = new List<IPackage>(new List<IPackage>()
            {
                packageMock.Object
            });

            var repository = new PackageRepository(loggerMock.Object, coll);

            // Act
            var packagesFound = repository.GetAll();

            // Assert
            Assert.AreEqual(1, packagesFound.Count());
        }
    }
}
