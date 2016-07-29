using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using ArmyOfCreatures.Extended;
using ArmyOfCreatures.Extended.Creatures;
using ArmyOfCreatures.Logic.Creatures;
using NUnit.Framework;

namespace ArmyOfCreatures.Tests
{
    [TestFixture]
    public class ExtendedCreaturesFactoryTests
    {
        [TestCase("AncientBehemoth", typeof(AncientBehemoth))]
        [TestCase("CyclopsKing", typeof(CyclopsKing))]
        [TestCase("Goblin", typeof(Goblin))]
        [TestCase("Griffin", typeof(Griffin))]
        [TestCase("WolfRaider", typeof(WolfRaider))]
        public void CreateCreature_ShouldReturnTheCorrespondingCreatureInstance_WhenTheStringPassedRepresentsValidCreature(string creatureName, Type expectedCreatureType)
        {
            var extendedCreaturesFactory = new ExtendedCreaturesFactory();

            var actualCreature = extendedCreaturesFactory.CreateCreature(creatureName);
            
            Assert.IsInstanceOf(expectedCreatureType, actualCreature);
        }

        [Test]
        public void CreateCreature_ShouldThrowArgumentException_WhenTheStringPassedRepresentsInvalidCreature()
        {
            var extendedCreaturesFactory = new ExtendedCreaturesFactory();
            var invalidCreatureName = "fhauisfqiuwf21721787gas8gf12";

            var exc = Assert.Throws<ArgumentException>(
                 () => extendedCreaturesFactory.CreateCreature(invalidCreatureName));

            StringAssert.Contains("Invalid creature type", exc.Message);
        }
    }
}
