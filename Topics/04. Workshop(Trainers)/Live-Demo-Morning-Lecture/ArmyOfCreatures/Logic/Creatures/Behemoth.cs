namespace ArmyOfCreatures.Logic.Creatures
{
    using ArmyOfCreatures.Logic.Specialties;

    public class Behemoth : Creature
    {
        public Behemoth()
            : base(17, 17, 160, 40)
        {
            this.AddSpecialty(new ReduceEnemyDefenseByPercentage(40));
        }
    }
}
