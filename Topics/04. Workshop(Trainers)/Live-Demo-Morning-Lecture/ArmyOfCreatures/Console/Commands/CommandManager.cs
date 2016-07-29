namespace ArmyOfCreatures.Console.Commands
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;

    using ArmyOfCreatures.Logic.Battles;

    public class CommandManager : ICommandManager
    {
        private readonly Dictionary<string, ICommand> commands =
            new Dictionary<string, ICommand>
            {
                { "add", new AddCommand() },
                { "attack", new AttackCommand() },
                { "skip", new SkipCommand() },
                { "exit", new ExitCommand() }
            };

        public void ProcessCommand(string commandLine, IBattleManager battleManager)
        {
            if (commandLine == null)
            {
                throw new ArgumentNullException("commandLine");
            }

            var commandParts = commandLine.Split(' ');
            var commandName = commandParts[0];
            if (!this.commands.ContainsKey(commandName))
            {
                throw new ArgumentException(
                    string.Format(CultureInfo.InvariantCulture, "Invalid command name \"{0}\"", commandName));
            }
            
            var command = this.commands[commandName];
            var commandArguments = commandParts.Skip(1).ToArray();
            command.ProcessCommand(battleManager, commandArguments);
        }
    }
}
