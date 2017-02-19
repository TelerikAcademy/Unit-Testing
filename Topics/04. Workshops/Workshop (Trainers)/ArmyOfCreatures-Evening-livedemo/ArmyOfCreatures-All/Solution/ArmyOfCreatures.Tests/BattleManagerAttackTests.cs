using System;
using ArmyOfCreatures.Logic;
using ArmyOfCreatures.Logic.Battles;
using ArmyOfCreatures.Logic.Creatures;
using ArmyOfCreatures.Tests.MockedClasses;
using Moq;
using NUnit.Framework;

namespace ArmyOfCreatures.Tests
{
    [TestFixture]
    public class BattleManagerAttackTests
    {
        [Test]
        public void Attack_WhenAttackingCreatureIdentifierIsNull_ShouldThrowArgumentException()
        {
            // Arrange
            var mockedFactory = new Mock<ICreaturesFactory>();
            var mockedLogger = new Mock<ILogger>();

            var battleManager = new MockedBattleManager(mockedFactory.Object, mockedLogger.Object);

            // The code itself should be refactored. Think about sealed class to be changed or the static method itself
            // You could use an unconstrained Mocking framework
            var identifier = CreatureIdentifier.CreatureIdentifierFromString("Angel(1)");

            // Act & Assert
            Assert.Throws<ArgumentException>(() => battleManager.Attack(identifier, identifier));
        }

        [Test]
        public void Attack_WhenDefenderCreatureIdentifierIsNull_ShouldThrowArgumentException()
        {
            // Arrange
            var mockedFactory = new Mock<ICreaturesFactory>();
            var mockedLogger = new Mock<ILogger>();

            var battleManager = new BattleManager(mockedFactory.Object, mockedLogger.Object);

            // The code itself should be refactored. Think about sealed class to be changed or the static method itself
            // You could use an unconstrained Mocking framework
            var identifier = CreatureIdentifier.CreatureIdentifierFromString("Pesho(1)");

            // Act & Assert
            Assert.Throws<ArgumentException>(() => battleManager.Attack(identifier, identifier));
        }

        [Test]
        public void Attack_WhenAttackIsSucessful_ShouldCallWriteline6Times()
        {
            // Arrange
            var mockedFactory = new Mock<CreaturesFactory>();
            var mockedLogger = new Mock<ILogger>();

            var battleManager = new MockedBattleManager(mockedFactory.Object, mockedLogger.Object);

            // The code itself should be refactored. Think about sealed class to be changed or the static method itself
            // You could use an unconstrained Mocking framework
            var identifierAttacker = CreatureIdentifier.CreatureIdentifierFromString("Angel(1)");
            var identifierDefender = CreatureIdentifier.CreatureIdentifierFromString("Angel(2)");

            var creature = new Angel();

            mockedFactory.Setup(x => x.CreateCreature(It.IsAny<string>())).Returns(creature);

            mockedLogger.Setup(x => x.WriteLine(It.IsAny<string>()));

            battleManager.AddCreatures(identifierAttacker, 1);
            battleManager.AddCreatures(identifierDefender, 1);

            // Act
            battleManager.Attack(identifierAttacker, identifierDefender);

            // Assert
            mockedLogger.Verify(x => x.WriteLine(It.IsAny<string>()), Times.Exactly(6));
        }

        [Test]
        public void Attack_WhenAttackingOwnArmy_ShouldThrow()
        {
            // Arrange
            var mockedFactory = new Mock<ICreaturesFactory>();
            var mockedLogger = new Mock<ILogger>();
            var mockedCreaturesInBattle = new Mock<ICreaturesInBattle>();

            var battleManager = new MockedBattleManager(mockedFactory.Object, mockedLogger.Object);

            // The code itself should be refactored. Think about sealed class to be changed or the static method itself
            // You could use an unconstrained Mocking framework
            var identifierAttacker = CreatureIdentifier.CreatureIdentifierFromString("Angel(1)");
            var identifierDefender = CreatureIdentifier.CreatureIdentifierFromString("Angel(1)");

            var creature = new Angel();

            mockedFactory.Setup(x => x.CreateCreature(It.IsAny<string>())).Returns(creature);
            mockedLogger.Setup(x => x.WriteLine(It.IsAny<string>()));

            battleManager.AddCreatures(identifierAttacker, 1);
            battleManager.AddCreatures(identifierDefender, 1);

            // Act and Assert
            Assert.Throws<ArgumentException>(() => battleManager.Attack(identifierAttacker, identifierDefender));
        }
    }
}
