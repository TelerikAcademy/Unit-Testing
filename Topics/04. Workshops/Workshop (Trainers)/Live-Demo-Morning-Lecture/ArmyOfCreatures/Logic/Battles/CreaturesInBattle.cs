namespace ArmyOfCreatures.Logic.Battles
{
    using System;
    using System.Globalization;

    using ArmyOfCreatures.Logic.Creatures;

    public sealed class CreaturesInBattle : ICreaturesInBattle
    {
        private decimal lastDamage;

        private int totalHitPoints;

        internal CreaturesInBattle(Creature creature, int count)
        {
            this.Creature = creature;
            this.PermanentAttack = creature.Attack;
            this.PermanentDefense = creature.Defense;
            this.TotalHitPoints = creature.HealthPoints * count;
            this.StartNewTurn();
        }

        public Creature Creature { get; private set; }

        public int CurrentAttack { get; set; }

        public int PermanentAttack { get; set; }

        public int CurrentDefense { get; set; }

        public int PermanentDefense { get; set; }

        public int TotalHitPoints
        {
            get
            {
                if (this.totalHitPoints < 0)
                {
                    return 0;
                }

                return this.totalHitPoints;
            }

            set
            {
                this.totalHitPoints = value;
            }
        }
        
        public int Count
        {
            get
            {
                var count = (int)Math.Ceiling((double)this.TotalHitPoints / this.Creature.HealthPoints);
                if (count < 0)
                {
                    return 0;
                }

                return count;
            }
        }

        public void DealDamage(ICreaturesInBattle defender)
        {
            if (defender == null)
            {
                throw new ArgumentNullException("defender");
            }

            // Calculate bonus for damage
            decimal attackBonus = 1.00M; // Initially 100%
            if (this.CurrentAttack > defender.CurrentDefense)
            {
                attackBonus += 0.05M * (this.CurrentAttack - defender.CurrentDefense);
            }

            // Calculate damage
            decimal damageToMake = this.Creature.Damage * this.Count;
            damageToMake = damageToMake * attackBonus;

            // Apply battle effects for damage (ChangeDamageWhenAttacking)
            foreach (var speciallity in this.Creature.Specialties)
            {
                damageToMake = speciallity.ChangeDamageWhenAttacking(this, defender, damageToMake);
            }

            // Calculate damage reductions
            if (defender.CurrentDefense > this.CurrentAttack)
            {
                decimal reduceDamage = 0.025M * (defender.CurrentDefense - this.CurrentAttack);
                if (reduceDamage > 0.7M)
                {
                    reduceDamage = 0.7M;
                }

                damageToMake = damageToMake * (1M - reduceDamage);
            }

            this.lastDamage = damageToMake;
            defender.TotalHitPoints -= (int)damageToMake;
        }

        public void Skip()
        {
            // Skipping adds 3 permanent defense for the creature
            this.PermanentDefense += 3;

            // Call ApplyOnSkip on creature
            foreach (var speciallity in this.Creature.Specialties)
            {
                speciallity.ApplyOnSkip(this);
            }
        }

        public void StartNewTurn()
        {
            this.CurrentAttack = this.PermanentAttack;
            this.CurrentDefense = this.PermanentDefense;
            this.lastDamage = 0;
        }

        public override string ToString()
        {
            return string.Format(
                CultureInfo.InvariantCulture, 
                "{0} {1} (ATT:{2}; DEF:{3}; THP:{4}; LDMG:{5:0.####})",
                this.Count,
                this.Creature.GetType().Name,
                this.CurrentAttack,
                this.CurrentDefense,
                this.TotalHitPoints,
                this.lastDamage);
        }
    }
}
