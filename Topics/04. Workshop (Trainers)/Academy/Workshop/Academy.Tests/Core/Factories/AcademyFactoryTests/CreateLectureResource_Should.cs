using Academy.Core.Factories;
using Academy.Models.Utils.LectureResources;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Tests.Core.Factories.AcademyFactoryTests
{
    [TestFixture]
    public class CreateLectureResource_Should
    {
        [Test]
        public void ReturnVideoResource_WhenVideoTypeIsPassed()
        {
            // Arrange
            var factory = AcademyFactory.Instance;

            // Act
            var resource = factory.CreateLectureResource("video", "Pesho's video", "11115");

            // Assert
            Assert.IsInstanceOf<VideoResource>(resource);
        }

        [Test]
        public void ReturnDemoResource_WhenDemoTypeIsPassed()
        {
            // Arrange
            var factory = AcademyFactory.Instance;

            // Act
            var resource = factory.CreateLectureResource("demo", "Pesho's video", "11115");

            // Assert
            Assert.IsInstanceOf<DemoResource>(resource);
        }


        [Test]
        public void ThrowArtgumentException_WhenInvalidResourceTypeIsPassed()
        {
            // Arrange
            var factory = AcademyFactory.Instance;

            // Act & Assert
            Assert.Throws<ArgumentException>(() => factory.CreateLectureResource("pesho", "Pesho's video", "11115"));
        }
    }
}
