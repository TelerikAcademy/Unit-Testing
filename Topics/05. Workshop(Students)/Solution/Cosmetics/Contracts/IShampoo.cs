namespace Cosmetics.Contracts
{
    using Cosmetics.Common;

    internal interface IShampoo : IProduct
    {
        uint Milliliters { get; }

        UsageType Usage { get; }
    }
}