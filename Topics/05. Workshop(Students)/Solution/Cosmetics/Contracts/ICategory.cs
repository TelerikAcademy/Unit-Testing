namespace Cosmetics.Contracts
{
    internal interface ICategory
    {
        string Name { get; }

        void AddProduct(IProduct cosmetics);

        void RemoveProduct(IProduct cosmetics);

        string Print();
    }
}
