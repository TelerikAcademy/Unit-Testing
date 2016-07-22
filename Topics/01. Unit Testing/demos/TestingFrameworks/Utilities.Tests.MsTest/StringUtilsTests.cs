using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSTestExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities.Tests.MsTest
{
    [TestClass]
    public class StringUtilsTests
    {
        [TestMethod]
        public void MSTest_StringUtils_ValidString_ShouldReturnTrue()
        {
            var util = new StringUtils();

            var result = util.ValidateString("Pesho", "^[A-Za-z]+$");

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void MSTest_StringUtils_InvalidString_ShouldReturnFalse()
        {
            var util = new StringUtils();

            var result = util.ValidateString("Pesho1", "^[A-Za-z]+$");

            Assert.IsFalse(result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void MSTest_StringUtils_InvalidPattern_ShouldThrowArgumentException()
        {
            var util = new StringUtils();

            var result = util.ValidateString("Pesho1", "^[A-Za-z+");
        }

        [TestMethod]
        public void MSTest_StringUtils_WithExtensions_InvalidPattern_ShouldThrowArgumentException()
        {
            var util = new StringUtils();

            ThrowsAssert.Throws<ArgumentException>(() => util.ValidateString("Pesho1", "^[A-Za-z+"));
        }
    }
}
