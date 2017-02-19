using Moq;
using NUnit.Framework;
using PackageManager.Models;
using PackageManager.Models.Contracts;
using PackageManager.Repositories.Contracts;
using System;

namespace AcademyPackageManager.Tests.Models.ProjectTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ReturnInstanceOfTheProjectClass_WhenTheValuesPassedAreValid()
        {
            // Arrange & Act
            var project = new Project("name", "location");

            // Assert
            Assert.IsInstanceOf<Project>(project);
        }

        [Test]
        public void ThrowArgumentNullException_WhenTheNameIsNull()
        {
            // Arrange & Act & Assert
            Assert.Throws<ArgumentNullException>(() => new Project(null, "location"));
        }

        [Test]
        public void ThrowArgumentNullException_WhenTheLocationIsNull()
        {
            // Arrange & Act & Assert
            Assert.Throws<ArgumentNullException>(() => new Project("name", null));
        }

        [Test]
        public void InitializeNewRepository_WhenTheParameterIsNotPassed()
        {
            // Arrange & Act
            var project = new Project("name", "location");

            // Assert
            Assert.IsInstanceOf<IRepository<IPackage>>(project.PackageRepository);
        }

        [Test]
        public void SetTheRepository_WhenTheParameterIsPassed()
        {
            // Arrange
            var repositoryMock = new Mock<IRepository<IPackage>>();

            // Act
            var project = new Project("name", "location", repositoryMock.Object);

            // Assert
            Assert.AreSame(repositoryMock.Object, project.PackageRepository);
        }

        [Test]
        public void SetTheName_WhenTheParameterIsPassed()
        {
            // Arrange & Act
            var project = new Project("name", "location");

            // Assert
            Assert.AreEqual("name", project.Name);
        }

        [Test]
        public void SetTheLocation_WhenTheParameterIsPassed()
        {
            // Arrange & Act
            var project = new Project("name", "location");

            // Assert
            Assert.AreEqual("location", project.Location);
        }
    }
}
