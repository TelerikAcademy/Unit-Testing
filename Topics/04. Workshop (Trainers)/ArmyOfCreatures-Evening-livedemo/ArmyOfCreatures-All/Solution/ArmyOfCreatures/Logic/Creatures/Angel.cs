using ArmyOfCreatures.Logic.Specialties;

namespace ArmyOfCreatures.Logic.Creatures
{
    public class Angel : Creature
    {
        public Angel()
            : base(20, 20, 200, 50)
        {
            this.AddSpecialty(new Hate(typeof(Devil)));
            this.AddSpecialty(new Hate(typeof(ArchDevil)));
        }
    }
}