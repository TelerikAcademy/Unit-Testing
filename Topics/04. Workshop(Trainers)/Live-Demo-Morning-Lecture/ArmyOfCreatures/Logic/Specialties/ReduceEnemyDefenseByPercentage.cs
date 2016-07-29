namespace ArmyOfCreatures.Logic.Specialties
{
    using System;
    using System.Globalization;

    using ArmyOfCreatures.Logic.Battles;

    public class ReduceEnemyDefenseByPercentage : Specialty
    {
        public ReduceEnemyDefenseByPercentage(decimal percentage)
        {
            if (percentage < 0 || percentage > 100)
            {
                throw new ArgumentOutOfRangeException("percentage", "The percentage argument should be between 0 and 100, inclusive");
            }

            this.Percentage = percentage;
        }

        private decimal Percentage { get; set; }

        public override void ApplyWhenAttacking(ICreaturesInBattle attackerWithSpecialty, ICreaturesInBattle defender)
        {
            if (attackerWithSpecialty == null)
            {
                throw new ArgumentNullException("attackerWithSpecialty");
            }

            if (defender == null)
            {
                throw new ArgumentNullException("defender");
            }

            var reduceDefenseBy = (int)(defender.CurrentDefense * (this.Percentage / 100.0M));
            defender.CurrentDefense = defender.CurrentDefense - reduceDefenseBy;
        }

        public override string ToString()
        {
            return string.Format(CultureInfo.InvariantCulture, "{0}({1})", base.ToString(), this.Percentage);
        }
    }
}
