namespace ArmyOfCreatures.Logic.Specialties
{
    using ArmyOfCreatures.Logic.Battles;

    public abstract class Specialty
    {
        public virtual void ApplyWhenAttacking(ICreaturesInBattle attackerWithSpecialty, ICreaturesInBattle defender)
        {
        }

        public virtual void ApplyWhenDefending(ICreaturesInBattle defenderWithSpecialty, ICreaturesInBattle attacker)
        {
        }

        public virtual void ApplyAfterDefending(ICreaturesInBattle defenderWithSpecialty)
        {
        }

        public virtual decimal ChangeDamageWhenAttacking(ICreaturesInBattle attackerWithSpecialty, ICreaturesInBattle defender, decimal currentDamage)
        {
            return currentDamage;
        }

        public virtual void ApplyOnSkip(ICreaturesInBattle skipCreature)
        {
        }

        public override string ToString()
        {
            return this.GetType().Name;
        }
    }
}
