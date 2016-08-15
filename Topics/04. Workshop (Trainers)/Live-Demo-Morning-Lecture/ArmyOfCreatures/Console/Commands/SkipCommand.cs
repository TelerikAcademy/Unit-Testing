namespace ArmyOfCreatures.Console.Commands
{
    using System;

    using ArmyOfCreatures.Logic.Battles;

    public class SkipCommand : ICommand
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

            if (arguments.Length < 1)
            {
                throw new ArgumentException("Invalid number of arguments for skip command");
            }

            var creatureIdentifierString = arguments[0];
            var creatureIdentifier = CreatureIdentifier.CreatureIdentifierFromString(creatureIdentifierString);

            battleManager.Skip(creatureIdentifier);
        }
    }
}
