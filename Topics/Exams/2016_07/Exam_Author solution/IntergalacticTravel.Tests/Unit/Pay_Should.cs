using System;
using IntergalacticTravel.Contracts;
using Moq;
using NUnit.Framework;

namespace IntergalacticTravel.Tests.Unit
{
    [TestFixture]
    public class Pay_Should
    {
        [Test]
        public void ThrowNullReferenceException_WhenTheObjectPassedIsNull()
        {
            // Arrange
            var unitId = 4124;
            var unitName = "Mecho";
            var unit = new IntergalacticTravel.Unit(unitId, unitName);

            // Act & Assert
            Assert.Throws<NullReferenceException>(() => unit.Pay((IResources)null));
        }

        [Test]
        public void DecreaseTheOwnerResourcesByTheAmountOfTheCost_WhenTheCostObjectIsNotNull()
        {
            // Arrange
            var unitId = 4124;
            var unitName = "Mecho";
            var unit = new IntergalacticTravel.Unit(unitId, unitName);

            var costMock = new Mock<IResources>();
            costMock.Setup(x => x.BronzeCoins).Returns(10);
            costMock.Setup(x => x.SilverCoins).Returns(20);
            costMock.Setup(x => x.GoldCoins).Returns(30);

            unit.Resources.Add(costMock.Object);
            unit.Resources.Add(costMock.Object);

            var expectedBronzeCoins = unit.Resources.BronzeCoins - costMock.Object.BronzeCoins;
            var expectedSilverCoins = unit.Resources.SilverCoins - costMock.Object.SilverCoins;
            var expectedGoldCoins = unit.Resources.GoldCoins - costMock.Object.GoldCoins;

            // Act
            unit.Pay(costMock.Object);
            var actualBronzeCoins = unit.Resources.BronzeCoins;
            var actualSilverCoins = unit.Resources.SilverCoins;
            var actualGoldCoins = unit.Resources.GoldCoins;

            // Assert
            Assert.AreEqual(expectedBronzeCoins, actualBronzeCoins);
            Assert.AreEqual(expectedSilverCoins, actualSilverCoins);
            Assert.AreEqual(expectedGoldCoins, actualGoldCoins);
        }

        [Test]
        public void ReturnNewResourcesObjectContainingTheSameAmountOfCoinsLikeTheCostObject_WhenTheCostObjectIsNotNullAndTheUnitHasTheRequiredAmountOfResourcesForPayment()
        {
            // Arrange
            var unitId = 4124;
            var unitName = "Mecho";
            var unit = new IntergalacticTravel.Unit(unitId, unitName);

            var costMock = new Mock<IResources>();
            costMock.Setup(x => x.BronzeCoins).Returns(10);
            costMock.Setup(x => x.SilverCoins).Returns(20);
            costMock.Setup(x => x.GoldCoins).Returns(30);

            var expectedBronzeCoins = costMock.Object.BronzeCoins;
            var expectedSilverCoins = costMock.Object.SilverCoins;
            var expectedGoldCoins = costMock.Object.GoldCoins;

            // Act
            var actualResources = unit.Pay(costMock.Object);

            // Assert
            Assert.AreEqual(expectedBronzeCoins, actualResources.BronzeCoins);
            Assert.AreEqual(expectedSilverCoins, actualResources.SilverCoins);
            Assert.AreEqual(expectedGoldCoins, actualResources.GoldCoins);
        }
    }
}
