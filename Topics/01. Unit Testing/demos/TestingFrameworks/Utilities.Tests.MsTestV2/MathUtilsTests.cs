using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities.Tests.MsTestV2
{
    [TestClass]
    public class MathUtilsTests
    {
        [TestMethod]
        public void V2_MathUtils_SumZeroNumbers_ShouldReturnZero()
        {
            var util = new MathUtils();
            var numbers = new List<int>() { };

            var result = util.Sum(numbers);

            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void V2_MathUtils_SumTwoPositiveNumbers_ShouldReturnCorrectResult()
        {
            var util = new MathUtils();
            var numbers = new List<int>() { 1, 2 };

            var result = util.Sum(numbers);

            Assert.AreEqual(3, result);
        }

        [TestMethod]
        public void V2_MathUtils_SumOneNegativeNumber_ShouldReturnTheNumberItself()
        {
            var util = new MathUtils();
            var numbers = new List<int>() { -1 };

            var result = util.Sum(numbers);

            Assert.AreEqual(-1, result);
        }


        [DataTestMethod]
        [DataRow("1,1", 2)]
        [DataRow("",0)]
        [DataRow("-1", -1)]
        public void V2_MathUtils_MultipleCases_ShouldReturnRightResult(string arr, int expected)
        {
            var util = new MathUtils();
            var numbers = arr.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse);

            var result = util.Sum(numbers);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void V2_MathUtils_NullCollectionPassed_ShouldThrowArgumentException()
        {
            var util = new MathUtils();
            List<int> numbers = null;

            Assert.ThrowsException<ArgumentNullException>(() => util.Sum(numbers));
        }
    }
}
