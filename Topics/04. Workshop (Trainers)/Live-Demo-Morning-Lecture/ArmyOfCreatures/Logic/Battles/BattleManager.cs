namespace ArmyOfCreatures.Logic.Battles
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;

    public class BattleManager : IBattleManager
    {
        private const string LogFormat = "--- {0} - {1}";

        private readonly ICollection<ICreaturesInBattle> firstArmyCreatures;

        private readonly ICollection<ICreaturesInBattle> secondArmyCreatures;

        private readonly ICreaturesFactory creaturesFactory;

        private readonly ILogger logger;

        public BattleManager(ICreaturesFactory creaturesFactory, ILogger logger)
        {
            this.firstArmyCreatures = new List<ICreaturesInBattle>();
            this.secondArmyCreatures = new List<ICreaturesInBattle>();
            this.creaturesFactory = creaturesFactory;
            this.logger = logger;
        }

        public void AddCreatures(CreatureIdentifier creatureIdentifier, int count)
        {
            if (creatureIdentifier == null)
            {
                throw new ArgumentNullException("creatureIdentifier");
            }

            var creature = this.creaturesFactory.CreateCreature(creatureIdentifier.CreatureType);
            var creaturesInBattle = new CreaturesInBattle(creature, count);
            this.AddCreaturesByIdentifier(creatureIdentifier, creaturesInBattle);

            this.logger.WriteLine(
                string.Format(
                    CultureInfo.InvariantCulture,
                    LogFormat,
                    string.Format(CultureInfo.InvariantCulture, "Creature added to army {0}", creatureIdentifier.ArmyNumber),
                    creature));
        }

        public void Attack(CreatureIdentifier attackerIdentifier, CreatureIdentifier defenderIdentifier)
        {
            var attackerCreature = this.GetByIdentifier(attackerIdentifier);
            if (attackerCreature == null)
            {
                throw new ArgumentException(
                    string.Format(CultureInfo.InvariantCulture, "Attacker not found: {0}", attackerIdentifier));
            }

            var defenderCreature = this.GetByIdentifier(defenderIdentifier);
            if (defenderCreature == null)
            {
                throw new ArgumentException(
                    string.Format(CultureInfo.InvariantCulture, "Defender not found: {0}", defenderIdentifier));
            }

            attackerCreature.StartNewTurn();
            defenderCreature.StartNewTurn();

            this.logger.WriteLine(string.Format(CultureInfo.InvariantCulture, LogFormat, "Attacker before", attackerCreature));
            this.logger.WriteLine(string.Format(CultureInfo.InvariantCulture, LogFormat, "Defender before", defenderCreature));

            // Call ApplyWhenAttacking on attacker
            foreach (var speciallity in attackerCreature.Creature.Specialties)
            {
                speciallity.ApplyWhenAttacking(attackerCreature, defenderCreature);
            }

            // Call ApplyWhenDefending on defender
            foreach (var speciallity in defenderCreature.Creature.Specialties)
            {
                speciallity.ApplyWhenDefending(defenderCreature, attackerCreature);
            }

            // Call ChangeDamage on attacker
            attackerCreature.DealDamage(defenderCreature);

            // Call ApplyAfterDefending on defender
            foreach (var speciallity in defenderCreature.Creature.Specialties)
            {
                speciallity.ApplyAfterDefending(defenderCreature);
            }

            this.logger.WriteLine(string.Format(CultureInfo.InvariantCulture, LogFormat, "Attacker after", attackerCreature));
            this.logger.WriteLine(string.Format(CultureInfo.InvariantCulture, LogFormat, "Defender after", defenderCreature));
        }

        public void Skip(CreatureIdentifier creatureIdentifier)
        {
            var creature = this.GetByIdentifier(creatureIdentifier);
            if (creature == null)
            {
                throw new ArgumentException(
                    string.Format(CultureInfo.InvariantCulture, "Skip creature not found: {0}", creatureIdentifier));
            }

            creature.StartNewTurn();

            this.logger.WriteLine(string.Format(CultureInfo.InvariantCulture, LogFormat, "Before skip", creature));

            creature.Skip();
            creature.StartNewTurn();

            this.logger.WriteLine(string.Format(CultureInfo.InvariantCulture, LogFormat, "After skip", creature));
        }
        
        protected virtual void AddCreaturesByIdentifier(CreatureIdentifier creatureIdentifier, ICreaturesInBattle creaturesInBattle)
        {
            if (creatureIdentifier == null)
            {
                throw new ArgumentNullException("creatureIdentifier");
            }

            if (creaturesInBattle == null)
            {
                throw new ArgumentNullException("creaturesInBattle");
            }

            if (creatureIdentifier.ArmyNumber == 1)
            {
                this.firstArmyCreatures.Add(creaturesInBattle);
            }
            else if (creatureIdentifier.ArmyNumber == 2)
            {
                this.secondArmyCreatures.Add(creaturesInBattle);
            }
            else
            {
                throw new ArgumentException(
                    string.Format(CultureInfo.InvariantCulture, "Invalid ArmyNumber: {0}", creatureIdentifier.ArmyNumber));
            }
        }

        protected virtual ICreaturesInBattle GetByIdentifier(CreatureIdentifier identifier)
        {
            if (identifier == null)
            {
                throw new ArgumentNullException("identifier");
            }

            if (identifier.ArmyNumber == 1)
            {
                return this.firstArmyCreatures.FirstOrDefault(x => x.Creature.GetType().Name == identifier.CreatureType);
            }

            if (identifier.ArmyNumber == 2)
            {
                return this.secondArmyCreatures.FirstOrDefault(x => x.Creature.GetType().Name == identifier.CreatureType);
            }

            throw new ArgumentException(
                string.Format(CultureInfo.InvariantCulture, "Invalid ArmyNumber: {0}", identifier.ArmyNumber));
        }
    }
}
