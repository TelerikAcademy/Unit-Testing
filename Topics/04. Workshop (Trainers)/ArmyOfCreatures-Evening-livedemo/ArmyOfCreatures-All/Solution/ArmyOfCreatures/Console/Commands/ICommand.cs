using ArmyOfCreatures.Logic.Battles;

namespace ArmyOfCreatures.Console.Commands
{
    public interface ICommand
    {
        void ProcessCommand(IBattleManager battleManager, params string[] arguments);
    }
}
