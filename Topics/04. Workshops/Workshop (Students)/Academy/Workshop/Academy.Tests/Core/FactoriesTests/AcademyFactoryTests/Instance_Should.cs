using Academy.Core.Contracts;
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
    public class AcademyFactoryTests
    {
        [Test]
        public void ReturnIAcademyFactoryInstance_WhenCalled()
        {
            // Arrange & Act
            var academyFactory = AcademyFactory.Instance;

            // Assert
            Assert.IsInstanceOf<IAcademyFactory>(academyFactory);
        }
    }
}
