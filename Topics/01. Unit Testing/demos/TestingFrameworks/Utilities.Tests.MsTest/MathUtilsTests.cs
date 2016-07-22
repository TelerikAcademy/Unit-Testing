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
    public class MathUtilsTests
    {
        //Needed only if using multiple parameters in tests
        private TestContext testContext;

        public TestContext TestContext
        {
            get
            {
                return this.testContext;
            }
            set
            {
                this.testContext = value;
            }
        }
        //Needed only if using multiple parameters in tests


        [TestMethod]
        public void MSTest_MathUtils_SumZeroNumbers_ShouldReturnZero()
        {
            var util = new MathUtils();
            var numbers = new List<int>() { };

            var result = util.Sum(numbers);

            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void MSTest_MathUtils_SumTwoPositiveNumbers_ShouldReturnCorrectResult()
        {
            var util = new MathUtils();
            var numbers = new List<int>() { 1, 2 };

            var result = util.Sum(numbers);

            Assert.AreEqual(3, result);
        }

        [TestMethod]
        public void MSTest_MathUtils_SumOneNegativeNumber_ShouldReturnTheNumberItself()
        {
            var util = new MathUtils();
            var numbers = new List<int>() { -1 };

            var result = util.Sum(numbers);

            Assert.AreEqual(-1, result);
        }

        [DeploymentItem(".\\Data","Data"), TestMethod]
        [DataSource(
            "Microsoft.VisualStudio.TestTools.DataSource.XML",
            "Data\\SumData.xml",
            "Row",
            DataAccessMethod.Sequential)]
        public void MSTest_MathUtils_MultipleCases_ShouldReturnRightResult()
        {
            var util = new MathUtils();

            var arr = ((string)TestContext.DataRow["Array"]).Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse);
            var expected = int.Parse((string)TestContext.DataRow["Result"]);

            var result = util.Sum(arr);

            Assert.AreEqual(expected, result);
        }

        // Expected exception with core functionallity
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void MSTest_MathUtils_NullCollectionPassed_ShouldThrowArgumentException()
        {
            var util = new MathUtils();
            List<int> numbers = null;

            var result = util.Sum(numbers);
        }

        // Expected exception with MSTestExtensions (nuget package)
        [TestMethod]
        public void MSTest_MathUtils_TestedWithExtensions_NullCollectionPassed_ShouldThrowArgumentException()
        {
            var util = new MathUtils();
            List<int> numbers = null;

            ThrowsAssert.Throws<ArgumentNullException>(() => util.Sum(numbers));
        }
    }
}
