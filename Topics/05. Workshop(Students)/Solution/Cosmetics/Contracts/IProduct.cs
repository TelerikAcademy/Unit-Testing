namespace Cosmetics.Contracts
{
    using Cosmetics.Common;

    internal interface IProduct
    {
        string Name { get; }

        string Brand { get; }

        decimal Price { get; }

        GenderType Gender { get; }

        string Print();
    }
}
