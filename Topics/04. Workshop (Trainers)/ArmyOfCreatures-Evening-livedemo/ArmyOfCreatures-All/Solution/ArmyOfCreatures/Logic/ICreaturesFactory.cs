using ArmyOfCreatures.Logic.Creatures;

namespace ArmyOfCreatures.Logic
{
    public interface ICreaturesFactory
    {
        Creature CreateCreature(string name);
    }
}
