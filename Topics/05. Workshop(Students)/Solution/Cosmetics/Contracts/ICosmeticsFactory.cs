namespace Cosmetics.Contracts
{
    using System.Collections.Generic;

    using Cosmetics.Common;

    internal interface ICosmeticsFactory
    {
        ICategory CreateCategory(string name);

        IShampoo CreateShampoo(string name, string brand, decimal price, GenderType gender, uint milliliters, UsageType usage);

        IToothpaste CreateToothpaste(string name, string brand, decimal price, GenderType gender, IList<string> ingredients);

        IShoppingCart CreateShoppingCart();
    }
}
