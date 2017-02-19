using ArmyOfCreatures.Logic.Specialties;

namespace ArmyOfCreatures.Logic.Creatures
{
    public class Devil : Creature
    {
        public Devil()
            : base(19, 26, 160, 35)
        {
            this.AddSpecialty(new Hate(typeof(Angel)));
            this.AddSpecialty(new Hate(typeof(Archangel)));
            this.AddSpecialty(new ReduceEnemyDefenseByPercentage(100));
        }
    }
}