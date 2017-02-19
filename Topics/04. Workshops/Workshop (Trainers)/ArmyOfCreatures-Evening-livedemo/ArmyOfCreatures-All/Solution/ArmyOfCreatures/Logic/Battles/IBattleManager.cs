namespace ArmyOfCreatures.Logic.Battles
{
    public interface IBattleManager
    {
        void AddCreatures(CreatureIdentifier creatureIdentifier, int count);

        void Attack(CreatureIdentifier attackerIdentifier, CreatureIdentifier defenderIdentifier);

        void Skip(CreatureIdentifier creatureIdentifier);
    }
}
