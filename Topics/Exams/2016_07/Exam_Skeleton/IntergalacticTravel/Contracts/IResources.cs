namespace IntergalacticTravel.Contracts
{
    public interface IResources
    {
        uint GoldCoins { get; set; }

        uint SilverCoins { get; set; }

        uint BronzeCoins { get; set; }

        void Add(IResources payment);

        bool IsEqualTo(IResources resource);

        void Clear();

        IResources Clone();
    }
}
