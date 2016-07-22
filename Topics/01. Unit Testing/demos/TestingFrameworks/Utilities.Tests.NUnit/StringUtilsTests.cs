using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities.Tests.NUnit
{
    [TestFixture]
    public class StringUtilsTests
    {
        [Test]
        public void V2_StringUtils_ValidString_ShouldReturnTrue()
        {
            var util = new StringUtils();

            var result = util.ValidateString("Pesho", "^[A-Za-z]+$");

            Assert.IsTrue(result);
        }

        [Test]
        public void V2_StringUtils_InvalidString_ShouldReturnFalse()
        {
            var util = new StringUtils();

            var result = util.ValidateString("Pesho1", "^[A-Za-z]+$");

            Assert.IsFalse(result);
        }

        [Test]
        public void V2_StringUtils_InvalidPattern_ShouldThrowArgumentException()
        {
            var util = new StringUtils();

            Assert.Throws<ArgumentException>(() => util.ValidateString("Pesho1", "^[A-Za-z+"));
        }
    }
}
