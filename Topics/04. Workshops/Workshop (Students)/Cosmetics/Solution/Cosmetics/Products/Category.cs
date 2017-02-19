namespace Cosmetics.Products
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Cosmetics.Contracts;
    using Cosmetics.Common;

    internal class Category : ICategory
    {
        private const int MinCategoryNameLength = 2;
        private const int MaxCategoryNameLength = 15;

        private string name;
        protected readonly IList<IProduct> products;

        public Category(string name)
        {
            this.Name = name;
            this.products = new List<IProduct>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                Validator.CheckIfStringIsNullOrEmpty(value, string.Format(GlobalErrorMessages.StringCannotBeNullOrEmpty, "Category name"));
                Validator.CheckIfStringLengthIsValid(value, MaxCategoryNameLength, MinCategoryNameLength, string.Format(GlobalErrorMessages.InvalidStringLength, "Category name", MinCategoryNameLength, MaxCategoryNameLength));
                this.name = value;
            }
        }

        public void AddProduct(IProduct product)
        {
            Validator.CheckIfNull(product, string.Format(GlobalErrorMessages.ObjectCannotBeNull, "Cosmetics to add to category"));
            this.products.Add(product);
        }

        public void RemoveProduct(IProduct product)
        {
            Validator.CheckIfNull(product, string.Format(GlobalErrorMessages.ObjectCannotBeNull, "Cosmetics to remove from category"));
            if (!this.products.Contains(product))
            {
                throw new InvalidOperationException(string.Format("Product {0} does not exist in category {1}!", product.Name, this.Name));
            }

            this.products.Remove(product);
        }

        public string Print()
        {
            var categoryString = string.Format("{0} category - {1} {2} in total", this.Name, this.products.Count, this.products.Count != 1 ? "products" : "product");

            var result = new StringBuilder();
            result.AppendLine(categoryString);

            var sortedProducts =
                this.products
                    .OrderBy(pr => pr.Brand)
                    .ThenByDescending(pr => pr.Price);

            foreach (var product in sortedProducts)
            {
                result.AppendLine(product.Print());
            }

            return result.ToString().Trim();
        }
    }
}
