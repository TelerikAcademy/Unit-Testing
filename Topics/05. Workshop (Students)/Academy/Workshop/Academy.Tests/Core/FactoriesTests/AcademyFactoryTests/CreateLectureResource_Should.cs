using Academy.Core.Factories;
using Academy.Models.Utils.LectureResources;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Tests.Core.FactoriesTests.AcademyFactoryTests
{
    [TestFixture]
    public class CreateLectureResource_Should
    {
        [Test]
        public void CreateVideoResource_WhenThePassedTypeIsVideo()
        {
            // Arrange
            var academyFactory = AcademyFactory.Instance;

            // Act
            var video = academyFactory.CreateLectureResource("video", "Valid", "url//myValidUrl");

            // Assert
            Assert.IsInstanceOf<VideoResource>(video);
        }

        [Test]
        public void CreatePresentationResource_WhenThePassedTypeIsPresentation()
        {
            // Arrange
            var academyFactory = AcademyFactory.Instance;

            // Act
            var presentation = academyFactory.CreateLectureResource("presentation", "Valid", "url//myValidUrl");

            // Assert
            Assert.IsInstanceOf<PresentationResource>(presentation);
        }

        [Test]
        public void CreateDemoResource_WhenThePassedTypeIsDemo()
        {
            // Arrange
            var academyFactory = AcademyFactory.Instance;

            // Act
            var demo = academyFactory.CreateLectureResource("demo", "Valid", "url//myValidUrl");

            // Assert
            Assert.IsInstanceOf<DemoResource>(demo);
        }

        [Test]
        public void CreateHomeworkResource_WhenThePassedTypeIsHomework()
        {
            // Arrange
            var academyFactory = AcademyFactory.Instance;

            // Act
            var homework = academyFactory.CreateLectureResource("homework", "Valid", "url//myValidUrl");

            // Assert
            Assert.IsInstanceOf<HomeworkResource>(homework);
        }

        [Test]
        public void ThrowArgumentException_WhenThePassedTypeIsNotAvailable()
        {
            // Arrange
            var academyFactory = AcademyFactory.Instance;

            // Act & Assert
            Assert.Throws<ArgumentException>(() => academyFactory.CreateLectureResource("invalid resource", "Valid", "url//myValidUrl"));
        }
    }
}
