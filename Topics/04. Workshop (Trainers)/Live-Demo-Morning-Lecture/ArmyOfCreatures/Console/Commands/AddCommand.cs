namespace ArmyOfCreatures.Console.Commands
{
    using System;
    using System.Globalization;

    using ArmyOfCreatures.Logic.Battles;

    public class AddCommand : ICommand
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
                throw new ArgumentException("Invalid number of arguments for add command");
            }

            var count = int.Parse(arguments[0], CultureInfo.InvariantCulture);
            var creatureIdentifierString = arguments[1];
            var creatureIdentifier = CreatureIdentifier.CreatureIdentifierFromString(creatureIdentifierString);

            battleManager.AddCreatures(creatureIdentifier, count);
        }
    }
}
