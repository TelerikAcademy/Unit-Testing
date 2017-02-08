using Cosmetics.Engine;
using Cosmetics.Products;

namespace Cosmetics
{
    public class CosmeticsProgram
    {
        public static void Main()
        {
            var factory = new CosmeticsFactory();
            var shoppingCart = new ShoppingCart();
            var consoleCommandParser = new ConsoleCommandParser();
            var engine = new CosmeticsEngine(factory, shoppingCart, consoleCommandParser);

            engine.Start();
        }
    }
}
