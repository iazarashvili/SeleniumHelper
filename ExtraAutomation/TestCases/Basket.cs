using ExtraAutomation.PageObject;
using NUnit.Framework;
using SeleniumHelper.Base;
using SeleniumHelper.ComponentHelper;

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
            AddProductQuantity();
            Assert.IsTrue(CheckMethods.CheckCount(BasketProductQuantity, OrderProdyctQuantity, WebDriver));
            ReduceProductQuantity();
            Assert.IsTrue(CheckMethods.CheckCount(BasketProductQuantity, OrderProdyctQuantity, WebDriver));
            BaseMethods.WaitSomeInterval(1);
            DeleteProducts();
        }
    }
}
