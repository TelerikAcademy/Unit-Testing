namespace Cosmetics.Tests.Engine
{
    using System.Collections.Generic;
    using System.Linq;

    using Cosmetics.Common;
    using Cosmetics.Contracts;
    using Cosmetics.Products;
    using Cosmetics.Tests.Engine.Mocks;

    using NUnit.Framework;
    using Moq;

    [TestFixture]
    public class CosmeticsEngineTests
    {
        [Test]
        public void Start_WhenInputStringIsValidCreateCategoryCommand_CategoryShouldBeAddedToList()
        {
            // Arrange
            var categoryName = "ForMale";

            var mockedFactory = new Mock<ICosmeticsFactory>();
            var mockedShoppingCart = new Mock<IShoppingCart>();
            var mockedCommandParser = new Mock<ICommandParser>();

            var mockedCommand = new Mock<ICommand>();
            var mockedCategory = new Mock<ICategory>();

            mockedCommand.SetupGet(x => x.Name).Returns("CreateCategory");
            mockedCommand.SetupGet(x => x.Parameters).Returns(new List<string>() { categoryName });
            mockedCommandParser.Setup(p => p.ReadCommands()).Returns(() => new List<ICommand>() { mockedCommand.Object });

            mockedCategory.SetupGet(x => x.Name).Returns(categoryName);
            mockedFactory.Setup(x => x.CreateCategory(categoryName)).Returns(mockedCategory.Object);

            var engine = new MockedCosmeticsEngine(mockedFactory.Object, mockedShoppingCart.Object, mockedCommandParser.Object);

            // Act
            engine.Start();

            // Assert
            Assert.IsTrue(engine.Categories.ContainsKey(categoryName));
            Assert.AreSame(mockedCategory.Object, engine.Categories[categoryName]);
        }

        [Test]
        public void Start_WhenInputStringIsValidAddToCategoryCommand_ProductShouldBeAddedToCategory()
        {
            // Arrange
            var categoryName = "ForMale";
            var productName = "White+";

            var mockedFactory = new Mock<ICosmeticsFactory>();
            var mockedShoppingCart = new Mock<IShoppingCart>();
            var mockedCommandParser = new Mock<ICommandParser>();

            var mockedCategory = new Mock<ICategory>();
            var mockedShampoo = new Mock<IShampoo>();
            var mockedCommand = new Mock<ICommand>();
            
            mockedCommand.SetupGet(x => x.Name).Returns("AddToCategory");
            mockedCommand.SetupGet(x => x.Parameters).Returns(new List<string>() { categoryName, productName });
            mockedCommandParser.Setup(p => p.ReadCommands()).Returns(() => new List<ICommand>() { mockedCommand.Object });

            var engine = new MockedCosmeticsEngine(mockedFactory.Object, mockedShoppingCart.Object, mockedCommandParser.Object);
            engine.Categories.Add(categoryName, mockedCategory.Object);
            engine.Products.Add(productName, mockedShampoo.Object);

            // Act
            engine.Start();

            // Assert
            mockedCategory.Verify(x => x.AddProduct(mockedShampoo.Object), Times.Once);
        }

        [Test]
        public void Start_WhenInputStringIsValidRemoveFromCategoryCommand_ProductShouldBeRemovedFromCategory()
        {
            // Arrange
            var categoryName = "ForMale";
            var productName = "White+";

            var mockedFactory = new Mock<ICosmeticsFactory>();
            var mockedShoppingCart = new Mock<IShoppingCart>();
            var mockedCommandParser = new Mock<ICommandParser>();

            var mockedCategory = new Mock<ICategory>();
            var mockedShampoo = new Mock<IShampoo>();
            var mockedCommand = new Mock<ICommand>();
            
            mockedCommand.SetupGet(x => x.Name).Returns("RemoveFromCategory");
            mockedCommand.SetupGet(x => x.Parameters).Returns(new List<string>() { categoryName, productName });
            mockedCommandParser.Setup(p => p.ReadCommands()).Returns(() => new List<ICommand>() { mockedCommand.Object });

            var engine = new MockedCosmeticsEngine(mockedFactory.Object, mockedShoppingCart.Object, mockedCommandParser.Object);
            engine.Categories.Add(categoryName, mockedCategory.Object);
            engine.Products.Add(productName, mockedShampoo.Object);

            // Act
            engine.Start();

            // Assert
            mockedCategory.Verify(x => x.RemoveProduct(mockedShampoo.Object), Times.Once);
        }

        [Test]
        public void Start_WhenInputStringIsValidShowCategoryCommand_RespectiveCategoryPrintMethodShouldBeInvoked()
        {
            // Arrange
            var categoryName = "ForMale";

            var mockedFactory = new Mock<ICosmeticsFactory>();
            var mockedShoppingCart = new Mock<IShoppingCart>();
            var mockedCommandParser = new Mock<ICommandParser>();

            var mockedCategory = new Mock<ICategory>();
            var mockedCommand = new Mock<ICommand>();

            mockedCommand.SetupGet(x => x.Name).Returns("ShowCategory");
            mockedCommand.SetupGet(x => x.Parameters).Returns(new List<string>() { categoryName });
            mockedCommandParser.Setup(p => p.ReadCommands()).Returns(() => new List<ICommand>() { mockedCommand.Object });

            var engine = new MockedCosmeticsEngine(mockedFactory.Object, mockedShoppingCart.Object, mockedCommandParser.Object);
            engine.Categories.Add(categoryName, mockedCategory.Object);

            // Act
            engine.Start();

            // Assert
            mockedCategory.Verify(x => x.Print(), Times.Once);
        }

        [Test]
        public void Start_WhenInputStringIsValidCreateShampooCommand_ShampooShouldBeAddedToProducts()
        {
            // Arrange
            var shampooName = "Cool";
            var shampooBrand = "Nivea";

            var mockedFactory = new Mock<ICosmeticsFactory>();
            var mockedShoppingCart = new Mock<IShoppingCart>();
            var mockedCommandParser = new Mock<ICommandParser>();

            var mockedCommand = new Mock<ICommand>();
            var mockedShampoo = new Mock<IShampoo>();
            
            mockedCommand.SetupGet(x => x.Name).Returns("CreateShampoo");
            mockedCommand.SetupGet(x => x.Parameters).Returns(new List<string>() { shampooName, shampooBrand, "0.50", "men", "500", "everyday" });
            mockedCommandParser.Setup(p => p.ReadCommands()).Returns(() => new List<ICommand>() { mockedCommand.Object });

            mockedFactory
                .Setup(x => x.CreateShampoo(shampooName, shampooBrand, 0.50M, GenderType.Men, 500, UsageType.EveryDay))
                .Returns(mockedShampoo.Object);

            var engine = new MockedCosmeticsEngine(mockedFactory.Object, mockedShoppingCart.Object, mockedCommandParser.Object);

            // Act
            engine.Start();

            // Assert
            Assert.IsTrue(engine.Products.ContainsKey(shampooName));
            Assert.AreSame(mockedShampoo.Object, engine.Products[shampooName]);
        }

        [Test]
        public void Start_WhenInputStringIsValidCreateCreateToothpasteCommand_ToothpasteShouldBeAddedToProducts()
        {
            // Arrange
            var toothpasteName = "White+";
            var toothpasteBrand = "Colgate";

            var mockedFactory = new Mock<ICosmeticsFactory>();
            var mockedShoppingCart = new Mock<IShoppingCart>();
            var mockedCommandParser = new Mock<ICommandParser>();

            var mockedCommand = new Mock<ICommand>();
            var mockedToothpaste = new Mock<IToothpaste>();
            
            mockedCommand.SetupGet(x => x.Name).Returns("CreateToothpaste");
            mockedCommand.SetupGet(x => x.Parameters).Returns(new List<string>() { toothpasteName, toothpasteBrand, "15.50", "men", "fluor,bqla,golqma" });
            mockedCommandParser.Setup(p => p.ReadCommands()).Returns(() => new List<ICommand>() { mockedCommand.Object });

            mockedFactory
                .Setup(x => x.CreateToothpaste(toothpasteName, toothpasteBrand, 15.50M, GenderType.Men, new List<string>() { "fluor", "bqla", "golqma" }))
                .Returns(mockedToothpaste.Object);

            var engine = new MockedCosmeticsEngine(mockedFactory.Object, mockedShoppingCart.Object, mockedCommandParser.Object);

            // Act
            engine.Start();

            // Assert
            Assert.IsTrue(engine.Products.ContainsKey(toothpasteName));
            Assert.AreSame(mockedToothpaste.Object, engine.Products[toothpasteName]);
        }

        [Test]
        public void Start_WhenInputStringIsValidAddToShoppingCartCommand_ProductShouldBeAddedToShoppingCart()
        {
            // Arrange
            var productName = "White+";

            var mockedFactory = new Mock<ICosmeticsFactory>();
            var mockedShoppingCart = new Mock<IShoppingCart>();
            var mockedCommandParser = new Mock<ICommandParser>();

            var mockedProduct = new Mock<IProduct>();
            var mockedCommand = new Mock<ICommand>();

            mockedCommand.SetupGet(x => x.Name).Returns("AddToShoppingCart");
            mockedCommand.SetupGet(x => x.Parameters).Returns(new List<string>() { productName });
            mockedCommandParser.Setup(p => p.ReadCommands()).Returns(() => new List<ICommand>() { mockedCommand.Object });

            var engine = new MockedCosmeticsEngine(mockedFactory.Object, mockedShoppingCart.Object, mockedCommandParser.Object);
            engine.Products.Add(productName, mockedProduct.Object);

            // Act
            engine.Start();

            // Assert
            mockedShoppingCart.Verify(x => x.AddProduct(mockedProduct.Object), Times.Once);
        }

        [Test]
        public void Start_WhenInputStringIsValidRemoveFromShoppingCartCommand_ProductShouldBeRemovedFromShoppingCart()
        {
            // Arrange
            var productName = "White+";

            var mockedFactory = new Mock<ICosmeticsFactory>();
            var mockedShoppingCart = new Mock<IShoppingCart>();
            var mockedCommandParser = new Mock<ICommandParser>();

            var mockedProduct = new Mock<IProduct>();
            var mockedCommand = new Mock<ICommand>();

            mockedCommand.SetupGet(x => x.Name).Returns("RemoveFromShoppingCart");
            mockedCommand.SetupGet(x => x.Parameters).Returns(new List<string>() { productName });
            mockedCommandParser.Setup(p => p.ReadCommands()).Returns(() => new List<ICommand>() { mockedCommand.Object });

            mockedShoppingCart.Setup(x => x.ContainsProduct(mockedProduct.Object)).Returns(true);

            var engine = new MockedCosmeticsEngine(mockedFactory.Object, mockedShoppingCart.Object, mockedCommandParser.Object);
            engine.Products.Add(productName, mockedProduct.Object);

            // Act
            engine.Start();

            // Assert
            mockedShoppingCart.Verify(x => x.RemoveProduct(mockedProduct.Object), Times.Once);
        }
    }
}
