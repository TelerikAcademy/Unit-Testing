using ArmyOfCreatures.Logic.Battles;

namespace ArmyOfCreatures.Console.Commands
{
    public interface ICommandManager
    {
        void ProcessCommand(string commandLine, IBattleManager battleManager);
    }
}