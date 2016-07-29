namespace ArmyOfCreatures.Logic.Battles
{
    using ArmyOfCreatures.Logic.Creatures;

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
