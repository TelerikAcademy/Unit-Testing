using IntergalacticTravel.Contracts;

namespace IntergalacticTravel
{
    internal class Unit : IUnit
    {
        private ILocation currentLocation;
        private ILocation previousLocation;
        private readonly int identificationNumber;
        private readonly string nickName;
        private readonly IResources resources;

        public Unit(int identificationNumber, string nickName)
        {
            this.identificationNumber = identificationNumber;
            this.nickName = nickName;
            this.resources = new Resources();
        }

        public ILocation CurrentLocation
        {
            get
            {
                return this.currentLocation;
            }

            set
            {
                this.currentLocation = value;
            }
        }

        public int IdentificationNumber
        {
            get
            {
                return this.identificationNumber;
            }
        }

        public string NickName
        {
            get
            {
                return this.nickName;
            }
        }

        public ILocation PreviousLocation
        {
            get
            {
                return this.previousLocation;
            }

            set
            {
                this.previousLocation = value;
            }
        }

        public IResources Resources
        {
            get
            {
                return this.resources;
            }
        }

        public bool CanPay(IResources cost)
        {
            return this.resources.GoldCoins >= cost.GoldCoins &&
                this.resources.SilverCoins >= cost.SilverCoins &&
                this.resources.BronzeCoins >= cost.BronzeCoins;
        }

        public IResources Pay(IResources cost)
        {
            this.resources.BronzeCoins -= cost.BronzeCoins;
            this.resources.SilverCoins -= cost.SilverCoins;
            this.resources.GoldCoins -= cost.GoldCoins;

            return new Resources(cost.BronzeCoins, cost.SilverCoins, cost.GoldCoins);
        }
    }
}
