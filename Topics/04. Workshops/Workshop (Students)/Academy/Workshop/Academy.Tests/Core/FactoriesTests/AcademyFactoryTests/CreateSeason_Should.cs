using Academy.Core.Factories;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Tests.Core.FactoriesTests.AcademyFactoryTests
{
    [TestFixture]
    public class CreateSeason_Should
    {
        [Test]
        public void ThrowException_WhenThePassedStringCouldNotBeParsed()
        {
            // Arrange
            var academyFactory = AcademyFactory.Instance;

            // Act & Assert
            Assert.Throws<ArgumentException>(()=>academyFactory.CreateSeason("2016", "2017", "20"));

        }
    }
}
