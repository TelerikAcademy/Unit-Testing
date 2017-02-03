using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities.Tests.NUnit
{
    [TestFixture]
    public class MathUtilsTests
    {
        [Test]
        public void ThrowArgumentException_WhenTheListIsNull()
        {
            // Arrange
            var utils = new MathUtils();

            // Act & Assert
            Assert.Throws<ArgumentException>(() => utils.Sum(null));
        }
    }
}
