using IntergalacticTravel.Exceptions;
using NUnit.Framework;

namespace IntergalacticTravel.Tests.UnitsFactory
{
    [TestFixture]
    public class GetUnit_Should
    {
        [Test]
        public void ReturnNewProcyon_WhenValidCommandIsPassed()
        {
            // Arrange
            var command = "create unit Procyon Gosho 1";
            var unitsFactory = new IntergalacticTravel.UnitsFactory();

            // Act
            var actualUnit = unitsFactory.GetUnit(command);

            // Assert
            Assert.IsInstanceOf<Procyon>(actualUnit);
        }

        [Test]
        public void ReturnNewLuyten_WhenValidCommandIsPassed()
        {
            // Arrange
            var command = "create unit Luyten Pesho 2";
            var unitsFactory = new IntergalacticTravel.UnitsFactory();

            // Act
            var actualUnit = unitsFactory.GetUnit(command);

            // Assert
            Assert.IsInstanceOf<Luyten>(actualUnit);
        }

        [Test]
        public void ReturnNewLacaille_WhenValidCommandIsPassed()
        {
            // Arrange
            var command = "create unit Lacaille Tosho 3";
            var unitsFactory = new IntergalacticTravel.UnitsFactory();

            // Act
            var actualUnit = unitsFactory.GetUnit(command);

            // Assert
            Assert.IsInstanceOf<Lacaille>(actualUnit);
        }

        [TestCase("create unit InvalidType Name 1")]
        [TestCase("create unit Luyten Name InvalidId")]
        public void ThrowInvalidUnitCreationCommandException_WhenTheCommandPassedIsNotInTheValidFormat(string invalidCommand)
        {
            // Arrange
            var unitsFactory = new IntergalacticTravel.UnitsFactory();

            // Act & Assert
            Assert.Throws<InvalidUnitCreationCommandException>(() => unitsFactory.GetUnit(invalidCommand));
        }
    }
}
