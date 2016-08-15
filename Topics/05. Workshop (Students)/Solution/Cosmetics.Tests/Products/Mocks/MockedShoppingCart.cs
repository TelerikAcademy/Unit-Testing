namespace Cosmetics.Tests.Products.Mocks
{
    using System.Collections.Generic;

    using Cosmetics.Contracts;
    using Cosmetics.Products;

    internal class MockedShoppingCart : ShoppingCart
    {
        public IList<IProduct> Products
        {
            get
            {
                return base.products;
            }
        }
    }
}
