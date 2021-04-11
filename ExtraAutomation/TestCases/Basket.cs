using ExtraAutomation.PageObject;
using NUnit.Framework;
using SeleniumHelper.Base;

namespace ExtraAutomation.TestCases
{

    [TestFixture]
    class Basket : BasketPageObject
    {
        [Test, Category("Basket Test")]

        public static void BasketTest()
        {

            AddProductInBasket();
            GetBasket();
            Assert.IsTrue(CheckMethods.CheckCount(BasketProductQuantity, OrderProdyctQuantity, WebDriver));
            AddProductQuantityMethod();
            Assert.IsTrue(CheckMethods.CheckCount(BasketProductQuantity, OrderProdyctQuantity, WebDriver));
            ReduceProductQuantityMethod();
            Assert.IsTrue(CheckMethods.CheckCount(BasketProductQuantity, OrderProdyctQuantity, WebDriver));
            BaseMethods.WaitSomeInterval(1);
            DeleteProducts();
        }
    }
}
