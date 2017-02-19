using ArmyOfCreatures.Logic.Creatures;

namespace ArmyOfCreatures.Logic.Battles
{
    public interface ICreaturesInBattle
    {
        Creature Creature { get; }

        int CurrentAttack { get; set; }

        int PermanentAttack { get; set; }

        int CurrentDefense { get; set; }

        int PermanentDefense { get; set; }

        int TotalHitPoints { get; set; }

        int Count { get; }

        void DealDamage(ICreaturesInBattle defender);

        void Skip();

        void StartNewTurn();
    }
}
