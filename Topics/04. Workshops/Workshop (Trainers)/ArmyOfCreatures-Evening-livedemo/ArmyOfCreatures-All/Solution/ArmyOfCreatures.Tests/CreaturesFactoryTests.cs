using System;
using ArmyOfCreatures.Extended;
using ArmyOfCreatures.Logic.Creatures;
using NUnit.Framework;

namespace ArmyOfCreatures.Tests
{
    [TestFixture]
    public class CreaturesFactoryTests
    {
        [TestCase("Angel", typeof(Angel))]
        [TestCase("Archangel", typeof(Archangel))]
        [TestCase("ArchDevil", typeof(ArchDevil))]
        [TestCase("Behemoth", typeof(Behemoth))]
        [TestCase("Devil", typeof(Devil))]
        public void CreaturesFactory_WhenValidNameIsPassed_ShouldReturnExpectedType(string name, Type expectedCreature)
        {
            // Arrange
            var factory = new ExtendedCreaturesFactory();

            // Act
            var creature = factory.CreateCreature(name);

            // Assert
            Assert.IsInstanceOf(expectedCreature.GetType(), creature.GetType());
        }

        [Test]
        public void CreaturesFactory_WhenInValidNameIsPassed_ShouldThrowArgumentException()
        {
            // Arrange
            var factory = new ExtendedCreaturesFactory();

            // Act & Assert
            Assert.Throws<ArgumentException>(() => factory.CreateCreature("Gosho"));
        }

        [Test]
        public void CreaturesFactory_WhenInValidNameIsPassed_ShouldThrowArgumentExceptionWithExpectedMessage()
        {
            // Arrange
            var factory = new ExtendedCreaturesFactory();

            // Act & Assert (method 1)
            try
            {
                factory.CreateCreature("Gosho");
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual($"Invalid creature type \"Gosho\"!", ex.Message);
            }

            //// Act & Assert (method 2)
            // Assert.That(()=>factory.CreateCreature("Gosho"), Throws.ArgumentException.With.Message.Contains($"Invalid creature type \"Gosho\"!"));
        }
    }
}
