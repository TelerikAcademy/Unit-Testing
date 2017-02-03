using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasker.Core.Providers;

namespace Tasker.Tests.Core.Providers
{
    [TestFixture]
    public class IdProviderTests
    {
        [Test]
        public void NextId_ShouldReturnIncrementedValue_WhenInvoced()
        {
            var sut = new IdProvider();

            var resultOne = sut.NextId();
            var resultTwo = sut.NextId();

            Assert.AreEqual(0, resultOne);
            Assert.AreEqual(1, resultTwo);
        }
    }
}
