namespace Cosmetics.Tests.Products
{
    using Cosmetics.Contracts;
    using Cosmetics.Tests.Products.Mocks;

    using Moq;
    using NUnit.Framework;

    [TestFixture]
    public class ShoppingCartTests
    {
        [Test]
        public void AddProduct_WhenProductParamIsValid_ShouldAddProductToList()
        {
            // Arrange
            var mockedProduct = new Mock<IProduct>();
            var shoppingCart = new MockedShoppingCart();

            // Act
            shoppingCart.AddProduct(mockedProduct.Object);

            // Assert
            Assert.AreEqual(true, shoppingCart.Products.Contains(mockedProduct.Object));
        }

        [Test]
        public void RemoveProduct_WhenProductParamIsValid_ShouldRemoveProductFromList()
        {
            // Arrange
            var mockedProduct = new Mock<IProduct>();
            var shoppingCart = new MockedShoppingCart();
            shoppingCart.Products.Add(mockedProduct.Object);

            // Act
            shoppingCart.RemoveProduct(mockedProduct.Object);

            // Assert
            Assert.AreEqual(false, shoppingCart.Products.Contains(mockedProduct.Object));
        }

        [Test]
        public void ContainsProduct_WhenProductParamIsValid_ShouldReturnTrueIfProductIsInList()
        {
            // Arrange
            var mockedProduct = new Mock<IProduct>();
            var shoppingCart = new MockedShoppingCart();
            shoppingCart.Products.Add(mockedProduct.Object);

            // Act
            var executionResult = shoppingCart.ContainsProduct(mockedProduct.Object);

            // Assert
            Assert.AreEqual(true, executionResult);
        }

        [Test]
        public void ContainsProduct_WhenProductParamIsValid_ShouldReturnFalseIfProductIsNotInList()
        {
            // Arrange
            var mockedProduct = new Mock<IProduct>();
            var shoppingCart = new MockedShoppingCart();

            // Act
            var executionResult = shoppingCart.ContainsProduct(mockedProduct.Object);

            // Assert
            Assert.AreEqual(false, executionResult);
        }

        [Test]
        public void TotalPrice_WhenThereAreNoProductsInList_ShouldReturnZero()
        {
            // Arrange
            var shoppingCart = new MockedShoppingCart();

            // Act
            var executionResult = shoppingCart.TotalPrice();

            // Assert
            Assert.AreEqual(0M, executionResult);
        }

        [Test]
        public void TotalPrice_WhenThereAreProductsInList_ShouldReturnTheTotalSumOfTheirPrices()
        {
            // Arrange
            var mockedProductOne = new Mock<IProduct>();
            var mockedProductTwo = new Mock<IProduct>();
            var shoppingCart = new MockedShoppingCart();

            mockedProductOne.SetupGet(x => x.Price).Returns(10M);
            mockedProductTwo.SetupGet(x => x.Price).Returns(20M);

            shoppingCart.Products.Add(mockedProductOne.Object);
            shoppingCart.Products.Add(mockedProductTwo.Object);

            // Act
            var executionResult = shoppingCart.TotalPrice();

            // Assert
            Assert.AreEqual(30M, executionResult);
        }
    }
}
