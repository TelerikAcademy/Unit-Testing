using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using IntergalacticTravel.Constants;
using IntergalacticTravel.Contracts;

namespace IntergalacticTravel
{
    [Serializable]
    public class Resources : IResources
    {
        private uint bronzeCoins;
        private uint silverCoins;
        private uint goldCoins;

        public Resources() 
            : this(GlobalConstants.BronzeCoinsDefaultAmount, 
                  GlobalConstants.SilverCoinsDefaultAmount, 
                  GlobalConstants.GoldCoinsDefaultAmount)
        {
        }

        public Resources(uint bronzeCoins, uint silverCoins, uint goldCoins)
        {
            this.bronzeCoins = bronzeCoins;
            this.silverCoins = silverCoins;
            this.goldCoins = goldCoins;
        }

        public uint BronzeCoins
        {
            get
            {
                return this.bronzeCoins;
            }
            set
            {
                this.bronzeCoins = value;
            }
        }

        public uint GoldCoins
        {
            get
            {
                return this.goldCoins;
            }
            set
            {
                this.goldCoins = value;
            }
        }

        public uint SilverCoins
        {
            get
            {
                return this.silverCoins;
            }
            set
            {
                this.silverCoins = value;
            }
        }

        public void Add(IResources payment)
        {
            this.bronzeCoins += payment.BronzeCoins;
            this.silverCoins += payment.SilverCoins;
            this.goldCoins += payment.GoldCoins;
        }

        public bool IsEqualTo(IResources resource)
        {
            return resource.GoldCoins == this.goldCoins &&
                resource.SilverCoins == this.silverCoins &&
                resource.BronzeCoins == this.bronzeCoins;
        }

        public void Clear()
        {
            this.bronzeCoins = 0;
            this.silverCoins = 0;
            this.goldCoins = 0;
        }

        public IResources Clone()
        {
            using (var stream = new MemoryStream())
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(stream, this);
                stream.Seek(0, SeekOrigin.Begin);

                return (IResources)formatter.Deserialize(stream);
            }
        }
    }
}
