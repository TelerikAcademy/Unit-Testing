namespace ArmyOfCreatures.Console.Commands
{
    using System;

    using ArmyOfCreatures.Logic.Battles;

    public class ExitCommand : ICommand
    {
        public void ProcessCommand(IBattleManager battleManager, params string[] arguments)
        {
            Environment.Exit(0);
        }
    }
}
