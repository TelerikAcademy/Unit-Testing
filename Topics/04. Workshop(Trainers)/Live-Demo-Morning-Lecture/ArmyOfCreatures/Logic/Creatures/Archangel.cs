namespace ArmyOfCreatures.Logic.Creatures
{
    using ArmyOfCreatures.Logic.Specialties;

    public class Archangel : Creature
    {
        public Archangel()
            : base(30, 30, 250, 50)
        {
            this.AddSpecialty(new Hate(typeof(Devil)));
            this.AddSpecialty(new Hate(typeof(ArchDevil)));
            this.AddSpecialty(new Resurrection());
        }
    }
}
