namespace ArmyOfCreatures.Logic
{
    using ArmyOfCreatures.Logic.Creatures;

    public interface ICreaturesFactory
    {
        Creature CreateCreature(string name);
    }
}
