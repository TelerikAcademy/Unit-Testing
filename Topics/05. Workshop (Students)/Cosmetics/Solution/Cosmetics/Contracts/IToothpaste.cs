namespace Cosmetics.Contracts
{
    using System.Collections.Generic;

    internal interface IToothpaste : IProduct
    {
        string Ingredients { get; }
    }
}