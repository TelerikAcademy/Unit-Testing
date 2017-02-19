using System;

using ArmyOfCreatures.Logic.Battles;

namespace ArmyOfCreatures.Console.Commands
{
    public class ExitCommand : ICommand
    {
        public void ProcessCommand(IBattleManager battleManager, params string[] arguments)
        {
            Environment.Exit(0);
        }
    }
}
