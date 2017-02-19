using NUnit.Framework;
using PackageManager.Enums;
using PackageManager.Models;
using System;

namespace AcademyPackageManager.Tests.Models.PackageVersionTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ReturnAnInstanceOfThePackageVersionCalss_WhenTheValuesAreValid()
        {
            // Arrange & Act
            var version = new PackageVersion(1, 2, 3, VersionType.alpha);

            // Assert
            Assert.IsInstanceOf<PackageVersion>(version);
        }

        [Test]
        public void SetMajor_WhenTheValueIsValid()
        {
            // Arrange & Act
            var version = new PackageVersion(1, 2, 3, VersionType.alpha);

            // Assert
            Assert.AreEqual(1, version.Major);
        }

        [Test]
        public void SetMinor_WhenTheValueIsValid()
        {
            // Arrange & Act
            var version = new PackageVersion(1, 2, 3, VersionType.alpha);

            // Assert
            Assert.AreEqual(2, version.Minor);
        }

        [Test]
        public void SetPatch_WhenTheValueIsValid()
        {
            // Arrange & Act
            var version = new PackageVersion(1, 2, 3, VersionType.alpha);

            // Assert
            Assert.AreEqual(3, version.Patch);
        }

        [Test]
        public void SetVersionType_WhenTheValueIsValid()
        {
            // Arrange & Act
            var version = new PackageVersion(1, 2, 3, VersionType.alpha);

            // Assert
            Assert.AreEqual(VersionType.alpha, version.VersionType);
        }

        [Test]
        public void ThrowArgumentException_WhenTheMajorIsNotValid()
        {
            // Arrange & Act
            Assert.Throws<ArgumentException>(() => new PackageVersion(-1, 2, 3, VersionType.alpha));
        }

        [Test]
        public void ThrowArgumentException_WhenTheMinorIsNotValid()
        {
            // Arrange & Act
            Assert.Throws<ArgumentException>(() => new PackageVersion(1, -1, 3, VersionType.alpha));
        }

        [Test]
        public void ThrowArgumentException_WhenThePatchIsNotValid()
        {
            // Arrange & Act
            Assert.Throws<ArgumentException>(() => new PackageVersion(1, 2, -1, VersionType.alpha));
        }

        [Test]
        public void ThrowArgumentException_WhenTheVerionTypeIsNotValid()
        {
            // Arrange & Act
            Assert.Throws<ArgumentException>(() => new PackageVersion(1, 2, 3, (VersionType)10));
        }
    }
}
