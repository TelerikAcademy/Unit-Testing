namespace ArmyOfCreatures.Logic.Specialties
{
    using System;
    using System.Globalization;

    using ArmyOfCreatures.Logic.Battles;

    public class Hate : Specialty
    {
        private readonly Type creatureTypeToHate;

        public Hate(Type creatureTypeToHate)
        {
            if (creatureTypeToHate == null)
            {
                throw new ArgumentNullException("creatureTypeToHate");
            }

            this.creatureTypeToHate = creatureTypeToHate;
        }

        public override decimal ChangeDamageWhenAttacking(
            ICreaturesInBattle attackerWithSpecialty,
            ICreaturesInBattle defender,
            decimal currentDamage)
        {
            if (attackerWithSpecialty == null)
            {
                throw new ArgumentNullException("attackerWithSpecialty");
            }

            if (defender == null)
            {
                throw new ArgumentNullException("defender");
            }

            if (defender.Creature.GetType() == this.creatureTypeToHate)
            {
                return currentDamage * 1.5M;
            }

            return currentDamage;
        }

        public override string ToString()
        {
            return string.Format(
                CultureInfo.InvariantCulture,
                "{0}({1})",
                base.ToString(),
                this.creatureTypeToHate.Name);
        }
    }
}
