namespace Cosmetics.Tests.Products
{
    using Cosmetics.Contracts;
    using Cosmetics.Products;
    using Cosmetics.Tests.Products.Mocks;

    using Moq;
    using NUnit.Framework;

    [TestFixture]
    public class CategoryTests
    {
        [Test]
        public void AddCosmetics_WhenProductParamIsValid_ShouldAddProductToList()
        {
            // Arrange
            var mockedProduct = new Mock<IProduct>();
            var category = new MockedCategory("ForMale");

            // Act
            category.AddProduct(mockedProduct.Object);

            // Assert
            Assert.IsTrue(category.Products.Contains(mockedProduct.Object));
        }

        [Test]
        public void RemoveCosmetics_WhenProductParamIsValid_ShouldRemoveProductFromList()
        {
            // Arrange
            var mockedProduct = new Mock<IProduct>();
            var category = new MockedCategory("ForMale");
            category.Products.Add(mockedProduct.Object);

            // Act
            category.RemoveProduct(mockedProduct.Object);

            // Assert
            Assert.IsFalse(category.Products.Contains(mockedProduct.Object));
        }        

        [Test]
        public void Print_WhenInvoked_ShouldReturnCategoryDetailsInValidStringFormat()
        {
            // Arrange
            var category = new Category("example");

            // Act
            var executionResult = category.Print();

            // Assert
            Assert.AreEqual("example category - 0 products in total", executionResult);
        }
    }
}