using System;
using System.Text;
using System.Collections.Generic;
using NUnit.Framework;
using ArmyOfCreatures.Logic.Battles;
using Moq;
using ArmyOfCreatures.Logic;
using ArmyOfCreatures.Logic.Creatures;

namespace ArmyOfCreatures.Tests
{
    [TestFixture]
    public class BattleManagerTests
    {
        private TestContext testContextInstance;

        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        [Test]
        public void Constructor_ShouldInstantiateObjectWhichContainsTheObjectsPassedAsParameters()
        {
            var mockedCreaturesFactory = new Mock<ICreaturesFactory>();
            var mockedLogger = new Mock<ILogger>();

            var battleManager =
                new BattleManager(
                    mockedCreaturesFactory.Object,
                    mockedLogger.Object);

            var wrappedBattleManager =
                new Microsoft.VisualStudio.TestTools.UnitTesting.PrivateObject(battleManager);

            var battleManagerCreaturesFactory =
                wrappedBattleManager.GetField("creaturesFactory");
            var battleManagerLogger =
                wrappedBattleManager.GetField("logger");

            Assert.AreSame(mockedCreaturesFactory.Object, battleManagerCreaturesFactory);
            Assert.AreSame(mockedLogger.Object, battleManagerLogger);
        }

        [Test]
        public void Attack_ShouldMakeAttackingAndDefendingCreatureCallStartNewTurnMethodExactlyOnceForEachCreature()
        {
            var mockedCreaturesFactory = new Mock<ICreaturesFactory>();
            var mockedLogger = new Mock<ILogger>();
            var mockedAttacker = new Mock<ICreaturesInBattle>();
            mockedAttacker.Setup(x => x.Creature).Returns(new Angel());

            var mockedDefender = new Mock<ICreaturesInBattle>();
            mockedDefender.Setup(x => x.Creature).Returns(new ArchDevil());

            var bm = new MockedBattleManager(
                mockedAttacker.Object,
                mockedDefender.Object,
                mockedCreaturesFactory.Object, 
                mockedLogger.Object);

            var attackerIdentifier = CreatureIdentifier.CreatureIdentifierFromString("Angel(1)");
            var defenderIdentifier = CreatureIdentifier.CreatureIdentifierFromString("ArchDevil(2)");

            bm.Attack(attackerIdentifier, defenderIdentifier);

            mockedAttacker.Verify(x => x.StartNewTurn(), Times.Once());
            mockedDefender.Verify(x => x.StartNewTurn(), Times.Once());
        }
    }

    public class MockedBattleManager : BattleManager
    {
        private ICreaturesInBattle attacker;
        private ICreaturesInBattle defender;

        public MockedBattleManager(
            ICreaturesInBattle attacker,
            ICreaturesInBattle defender,
            ICreaturesFactory creaturesFactory,
            ILogger logger)
            : base(creaturesFactory, logger)
        {
            this.attacker = attacker;
            this.defender = defender;
        }

        protected override ICreaturesInBattle GetByIdentifier(
            CreatureIdentifier identifier)
        {
            if (identifier.ArmyNumber == 1)
            {
                return this.attacker;
            }

            else if (identifier.ArmyNumber == 2)
            {
                return this.defender;
            }

            return null;
        }
    }
}
