namespace ArmyOfCreatures.Console.Commands
{
    using ArmyOfCreatures.Logic.Battles;

    public interface ICommand
    {
        void ProcessCommand(IBattleManager battleManager, params string[] arguments);
    }
}
