using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities.Tests.MsTestV2
{
    [TestClass]
    public class StringUtilsTests
    {
        [TestMethod]
        public void V2_StringUtils_ValidString_ShouldReturnTrue()
        {
            var util = new StringUtils();

            var result = util.ValidateString("Pesho", "^[A-Za-z]+$");

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void V2_StringUtils_InvalidString_ShouldReturnFalse()
        {
            var util = new StringUtils();

            var result = util.ValidateString("Pesho1", "^[A-Za-z]+$");

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void V2_StringUtils_InvalidPattern_ShouldThrowArgumentException()
        {
            var util = new StringUtils();

            Assert.ThrowsException<ArgumentException>(() => util.ValidateString("Pesho1", "^[A-Za-z+"));
        }
    }
}
