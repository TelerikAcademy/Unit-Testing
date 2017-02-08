using NUnit.Framework;
using Tasker.Core.Providers;

namespace Tasker.Tests.Core.Provider.IdProviderTests
{
    [TestFixture]
    public class NextIdTests
    {
        [Test]
        public void NextId_ShouldReturnIncrementedValue_WhenInvoked()
        {
            var sut = new IdProvider();

            var resultOne = sut.NextId();
            var resultTwo = sut.NextId();

            Assert.AreEqual(1, resultTwo - resultOne);
        }
    }
}
