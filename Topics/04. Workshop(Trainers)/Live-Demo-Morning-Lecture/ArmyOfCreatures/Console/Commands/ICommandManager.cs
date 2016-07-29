namespace ArmyOfCreatures.Console.Commands
{
    using ArmyOfCreatures.Logic.Battles;

    public interface ICommandManager
    {
        void ProcessCommand(string commandLine, IBattleManager battleManager);
    }
}