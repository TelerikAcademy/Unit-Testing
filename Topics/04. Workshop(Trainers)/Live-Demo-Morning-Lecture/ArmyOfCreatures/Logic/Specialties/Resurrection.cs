namespace ArmyOfCreatures.Logic.Specialties
{
    using System;

    using ArmyOfCreatures.Logic.Battles;

    public class Resurrection : Specialty
    {
        public override void ApplyAfterDefending(ICreaturesInBattle defenderWithSpecialty)
        {
            if (defenderWithSpecialty == null)
            {
                throw new ArgumentNullException("defenderWithSpecialty");
            }

            if (defenderWithSpecialty.TotalHitPoints > 0)
            {
                defenderWithSpecialty.TotalHitPoints = defenderWithSpecialty.Count
                                                       * defenderWithSpecialty.Creature.HealthPoints;
            }
        }
    }
}
