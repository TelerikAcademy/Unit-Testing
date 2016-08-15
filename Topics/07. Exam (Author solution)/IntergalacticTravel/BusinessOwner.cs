using System.Collections.Generic;
using IntergalacticTravel.Contracts;

namespace IntergalacticTravel
{
    internal class BusinessOwner : Unit, IBusinessOwner
    {
        private readonly ICollection<ITeleportStation> teleportStations;

        public BusinessOwner(int identificationNumber, string nickName, IEnumerable<ITeleportStation> teleportStations) : base(identificationNumber, nickName)
        {
            this.teleportStations = (ICollection<ITeleportStation>)teleportStations;
        }

        public ICollection<ITeleportStation> TeleportStations
        {
            get
            {
                return this.teleportStations;
            }
        }

        public void CollectProfits()
        {
            foreach(var teleportStation in this.teleportStations)
            {
                var profit = teleportStation.PayProfits(this);
                this.Resources.Add(profit);
            }
        }
    }
}
