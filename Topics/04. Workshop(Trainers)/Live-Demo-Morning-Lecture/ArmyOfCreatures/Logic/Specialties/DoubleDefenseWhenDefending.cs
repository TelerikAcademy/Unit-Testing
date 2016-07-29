namespace ArmyOfCreatures.Logic.Specialties
{
    using System;
    using System.Globalization;

    using ArmyOfCreatures.Logic.Battles;

    public class DoubleDefenseWhenDefending : Specialty
    {
        private int rounds;

        public DoubleDefenseWhenDefending(int rounds)
        {
            if (rounds <= 0)
            {
                throw new ArgumentOutOfRangeException("rounds", "The number of rounds should be greater than 0");
            }

            this.rounds = rounds;
        }

        public override void ApplyWhenDefending(ICreaturesInBattle defenderWithSpecialty, ICreaturesInBattle attacker)
        {
            if (defenderWithSpecialty == null)
            {
                throw new ArgumentNullException("defenderWithSpecialty");
            }

            if (attacker == null)
            {
                throw new ArgumentNullException("attacker");
            }

            if (this.rounds <= 0)
            {
                // Effect expires after fixed number of rounds
                return;
            }

            defenderWithSpecialty.CurrentDefense *= 2;
            this.rounds--;
        }

        public override string ToString()
        {
            return string.Format(CultureInfo.InvariantCulture, "{0}({1})", base.ToString(), this.rounds);
        }
    }
}
