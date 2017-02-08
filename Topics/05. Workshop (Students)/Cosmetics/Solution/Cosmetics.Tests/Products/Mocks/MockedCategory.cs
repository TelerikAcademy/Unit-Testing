namespace Cosmetics.Tests.Products.Mocks
{
    using System.Collections.Generic;

    using Cosmetics.Contracts;
    using Cosmetics.Products;

    internal class MockedCategory : Category
    {
        public MockedCategory(string name) : base(name)
        {
        }

        public IList<IProduct> Products
        {
            get
            {
                return base.products;
            }
        }
    }
}
