using ArmyOfCreatures.Logic.Specialties;

namespace ArmyOfCreatures.Logic.Creatures
{
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
