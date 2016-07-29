namespace ArmyOfCreatures.Console.Commands
{
    using System;

    using ArmyOfCreatures.Logic.Battles;

    public class AttackCommand : ICommand
    {
        public void ProcessCommand(IBattleManager battleManager, params string[] arguments)
        {
            if (battleManager == null)
            {
                throw new ArgumentNullException("battleManager");
            }

            if (arguments == null)
            {
                throw new ArgumentNullException("arguments");
            }

            if (arguments.Length < 2)
            {
                throw new ArgumentException("Invalid number of arguments for attack command");
            }

            var attackerIdentifierString = arguments[0];
            var attackerIdentifier = CreatureIdentifier.CreatureIdentifierFromString(attackerIdentifierString);

            var defenderIdentifierString = arguments[1];
            var defenderIdentifier = CreatureIdentifier.CreatureIdentifierFromString(defenderIdentifierString);

            battleManager.Attack(attackerIdentifier, defenderIdentifier);
        }
    }
}
