using System;
using NUnit.Framework;

namespace IntergalacticTravel.Tests.ResourcesFactory
{
    [TestFixture]
    public class GetResources_Should
    {
        [TestCase("create resources gold(20) silver(30) bronze(40)")]
        [TestCase("create resources gold(20) bronze(40) silver(30)")]
        [TestCase("create resources silver(30) bronze(40) gold(20)")]
        [TestCase("create resources silver(30) gold(20) bronze(40)")]
        [TestCase("create resources bronze(40) gold(20) silver(30)")]
        [TestCase("create resources bronze(40) silver(30) gold(20)")]
        public void ReturnNewResourcesWithCorrectlySetUpProperties_WhenTheCommandPassedIsValid_NoMatterWhatIsTheOrderOfTheParameters(string command)
        {
            // Arrange
            var expectedBronzeCoinsAmount = 40;
            var expectedSilverCoinsAmount = 30;
            var expectedGoldCoinsAmount = 20;
            var resourcesFactory = new IntergalacticTravel.ResourcesFactory();

            // Act
            var actualResourcesAmount = resourcesFactory.GetResources(command);

            // Assert
            Assert.AreEqual(expectedBronzeCoinsAmount, actualResourcesAmount.BronzeCoins);
            Assert.AreEqual(expectedSilverCoinsAmount, actualResourcesAmount.SilverCoins);
            Assert.AreEqual(expectedGoldCoinsAmount, actualResourcesAmount.GoldCoins);
        }


        [TestCase("create resources x y z")]
        [TestCase("tansta resources a b")]
        [TestCase("absolutelyRandomStringThatMustNotBeAValidCommand")]
        public void ThrowInvalidOperationExceptionWhichContainsTheStringCommand_WhenTheInputStringRepresentsInvalidCommand(string invalidCommand)
        {
            // Arrange
            var resourcesFactory = new IntergalacticTravel.ResourcesFactory();
            var expectedExceptionMessage = "command";

            // Act & Assert
            var exc = Assert.Throws<InvalidOperationException>(
                () => resourcesFactory.GetResources(invalidCommand));
            var actualExceptionMessage = exc.Message;

            // Assert
            StringAssert.Contains(expectedExceptionMessage, actualExceptionMessage);
        }

        [TestCase("create resources silver(10) gold(97853252356623523532) bronze(20)")]
        [TestCase("create resources silver(555555555555555555555555555555555) gold(97853252356623523532999999999) bronze(20)")]
        [TestCase("create resources silver(10) gold(20) bronze(4444444444444444444444444444444444444)")]
        public void ThrowOverflowException_WhenTheInputStringRepresentsValidCommandButAnyOfTheValuesThatRepresentTheResourceAmountIsLargerThanTheMaximumValueAllowed(string command)
        {
            // Arrange
            var resourcesFactory = new IntergalacticTravel.ResourcesFactory();

            // Act & Assert
            Assert.Throws<OverflowException>(
                () => resourcesFactory.GetResources(command));
        }
    }
}
