using System;
using ArmyOfCreatures.Logic;
using ArmyOfCreatures.Logic.Battles;
using ArmyOfCreatures.Logic.Creatures;
using Moq;
using NUnit.Framework;
using Ploeh.AutoFixture;
using Ploeh.AutoFixture.Kernel;

namespace ArmyOfCreatures.Tests
{
    [TestFixture]
    public class BattleManagerAddCreaturesTests
    {
        [Test]
        public void AddCreatures_WhenCreatureIdentifierIsNull_ShouldThrowArgumentNullException()
        {
            // Arrange
            var mockedFactory = new Mock<ICreaturesFactory>();
            var mockedLogger = new Mock<ILogger>();

            var battleManager = new BattleManager(null, mockedLogger.Object);

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => battleManager.AddCreatures(null, 1));
        }

        [Test]
        public void AddCreatures_WhenValidIdentifierIsPassed_FactoryShouldCallCreateCreature()
        {
            // Arrange
            var mockedFactory = new Mock<ICreaturesFactory>();
            var mockedLogger = new Mock<ILogger>();

            var battleManager = new BattleManager(mockedFactory.Object, mockedLogger.Object);

            var fixture = new Fixture();

            fixture.Customizations.Add(
                    new TypeRelay(
                        typeof(Creature),
                        typeof(Angel)));

            var creature = fixture.Create<Creature>();

            mockedFactory.Setup(x => x.CreateCreature(It.IsAny<string>())).Returns(creature);

            // The code itself should be refactored. Think about sealed class to be changed or the static method itself
            // You could use an unconstrained Mocking framework
            var identifier = CreatureIdentifier.CreatureIdentifierFromString("Angel(1)");

            // Act
            battleManager.AddCreatures(identifier, 1);

            // Assert
            mockedFactory.Verify(x => x.CreateCreature(It.IsAny<string>()), Times.Exactly(1));
        }

        [Test]
        public void AddCreatures_WhenValidIdentifierIsPassed_WritelineShoulbeCalled()
        {
            var mockedFactory = new Mock<ICreaturesFactory>();
            var mockedLogger = new Mock<ILogger>();

            var battleManager = new BattleManager(mockedFactory.Object, mockedLogger.Object);

            var fixture = new Fixture();

            fixture.Customizations.Add(
                    new TypeRelay(
                        typeof(Creature),
                        typeof(Angel)));

            var creature = fixture.Create<Creature>();

            // var creature = new Angel();
            mockedFactory.Setup(x => x.CreateCreature(It.IsAny<string>())).Returns(creature);

            mockedLogger.Setup(x => x.WriteLine(It.IsAny<string>()));

            // The code itself should be refactored. Think about sealed class to be changed or the static method itself
            // You could use an unconstrained Mocking framework
            var identifier = CreatureIdentifier.CreatureIdentifierFromString("Angel(1)");

            // Act
            battleManager.AddCreatures(identifier, 1);

            // Assert
            mockedLogger.Verify(x => x.WriteLine(It.IsAny<string>()), Times.Exactly(1));
        }
    }
}
