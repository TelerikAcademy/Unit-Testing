namespace ArmyOfCreatures.Logic.Specialties
{
    using System;
    using System.Globalization;

    using ArmyOfCreatures.Logic.Battles;

    public class AddDefenseWhenSkip : Specialty
    {
        private readonly int defenseToAdd;

        public AddDefenseWhenSkip(int defenseToAdd)
        {
            if (defenseToAdd < 1 || defenseToAdd > 20)
            {
                throw new ArgumentOutOfRangeException("defenseToAdd", "defenseToAdd should be between 1 and 20, inclusive");
            }

            this.defenseToAdd = defenseToAdd;
        }

        public override void ApplyOnSkip(ICreaturesInBattle skipCreature)
        {
            if (skipCreature == null)
            {
                throw new ArgumentNullException("skipCreature");
            }

            skipCreature.PermanentDefense += this.defenseToAdd;
        }

        public override string ToString()
        {
            return string.Format(CultureInfo.InvariantCulture, "{0}({1})", base.ToString(), this.defenseToAdd);
        }
    }
}
