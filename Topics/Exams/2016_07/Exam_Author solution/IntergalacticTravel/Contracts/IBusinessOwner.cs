using System.Collections.Generic;

namespace IntergalacticTravel.Contracts
{
    public interface IBusinessOwner : IUnit
    {
        ICollection<ITeleportStation> TeleportStations { get; }
    }
}
