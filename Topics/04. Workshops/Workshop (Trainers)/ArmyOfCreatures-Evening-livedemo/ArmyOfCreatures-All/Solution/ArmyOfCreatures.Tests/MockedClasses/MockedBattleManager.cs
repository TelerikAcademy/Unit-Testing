using System.Collections.Generic;
using System.Linq;
using ArmyOfCreatures.Logic;
using ArmyOfCreatures.Logic.Battles;

namespace ArmyOfCreatures.Tests.MockedClasses
{
    public class MockedBattleManager : BattleManager
    {
        public MockedBattleManager(ICreaturesFactory factory, ILogger logger)
            : base(factory, logger)
        {
            this.FirstArmyOfCreatures = new List<ICreaturesInBattle>();
            this.SecondArmyOfCreatures = new List<ICreaturesInBattle>();
        }

        public ICollection<ICreaturesInBattle> FirstArmyOfCreatures { get; set; }

        public ICollection<ICreaturesInBattle> SecondArmyOfCreatures { get; set; }

        protected override void AddCreaturesByIdentifier(CreatureIdentifier creatureIdentifier, ICreaturesInBattle creaturesInBattle)
        {
            if (creatureIdentifier.ArmyNumber == 1)
            {
                this.FirstArmyOfCreatures.Add(creaturesInBattle);
            }
            else if (creatureIdentifier.ArmyNumber == 2)
            {
                this.SecondArmyOfCreatures.Add(creaturesInBattle);
            }
        }

        protected override ICreaturesInBattle GetByIdentifier(CreatureIdentifier identifier)
        {
            if (identifier.ArmyNumber == 1)
            {
                return this.FirstArmyOfCreatures.FirstOrDefault(x => x.Creature.GetType().Name == identifier.CreatureType);
            }
            else
            {
                return this.SecondArmyOfCreatures.FirstOrDefault(x => x.Creature.GetType().Name == identifier.CreatureType);
            }
        }
    }
}
