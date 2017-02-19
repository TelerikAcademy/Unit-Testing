namespace IntergalacticTravel.Contracts
{
    public interface ITeleportStation
    {
        void TeleportUnit(IUnit unitToTeleport, ILocation targetLocation);

        IResources PayProfits(IBusinessOwner owner);
    }
}
