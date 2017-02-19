using System;
using ArmyOfCreatures.Logic.Battles;
using NUnit.Framework;

namespace ArmyOfCreatures.Tests
{
    [TestFixture]
    public class CreatureIdentifierTests
    {
        [Test]
        public void CreatureIdentifier_WhenNullValueIsPassed_ShouldThrowArgumentNullException()
        {
            // Arrange, Act & Assert
            Assert.Throws<ArgumentNullException>(() => CreatureIdentifier.CreatureIdentifierFromString(null));
        }

        [Test]
        public void CreatureIdentifier_WhenInvalidValueToParseIntIsPassed_ShouldThrowArgumentNullException()
        {
            // Arrange, Act & Assert
            Assert.Throws<FormatException>(() => CreatureIdentifier.CreatureIdentifierFromString("Angel(test)"));
        }

        [Test]
        public void CreatureIdentifier_WhenInvalidValueIsPassed_ShouldThrowIndexOutOfRangeException()
        {
            // Arrange, Act & Assert
            Assert.Throws<IndexOutOfRangeException>(() => CreatureIdentifier.CreatureIdentifierFromString("Angel"));
        }

        [Test]
        public void CreatureIdentifier_WhenValidValueIsPassed_ShouldReturnExpectedType()
        {
            // Act
            var identifier = CreatureIdentifier.CreatureIdentifierFromString("Angel(1)");

            // Assert
            Assert.IsInstanceOf<CreatureIdentifier>(identifier);
        }

        [Test]
        public void CreatureIdentifier_WhenValidValueIsPassed_ShouldReturnExpectedCreatureType()
        {
            // Act
            var identifier = CreatureIdentifier.CreatureIdentifierFromString("Angel(1)");

            // Assert
            Assert.AreEqual("Angel", identifier.CreatureType);
        }

        [Test]
        public void CreatureIdentifier_WhenValidValueIsPassed_ShouldReturnExpectedArmyNumber()
        {
            // Act
            var identifier = CreatureIdentifier.CreatureIdentifierFromString("Angel(1)");

            // Assert
            Assert.AreEqual(1, identifier.ArmyNumber);
        }

        [Test]
        public void CreatureIdentifier_WhenValidValueIsPassed_ToStringShouldReturnExpectedString()
        {
            // Arrange
            var identifier = CreatureIdentifier.CreatureIdentifierFromString("Angel(1)");

            // Act
            var result = identifier.ToString();

            // Assert
            Assert.AreEqual("Angel(1)", result);
        }
    }
}
