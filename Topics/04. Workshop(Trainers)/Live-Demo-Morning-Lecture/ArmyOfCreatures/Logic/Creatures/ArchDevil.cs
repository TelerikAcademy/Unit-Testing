namespace ArmyOfCreatures.Logic.Creatures
{
    using ArmyOfCreatures.Logic.Specialties;

    public class ArchDevil : Creature
    {
        public ArchDevil()
            : base(21, 28, 200, 35)
        {
            this.AddSpecialty(new Hate(typeof(Angel)));
            this.AddSpecialty(new Hate(typeof(Archangel)));
            this.AddSpecialty(new ReduceEnemyDefenseByPercentage(100));
        }
    }
}