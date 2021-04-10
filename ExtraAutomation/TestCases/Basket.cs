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
            Assert.IsTrue(CheckMethods.CheckCount(basketProductQuantity, orderProdyctQuantity, WebDriver));
            AddProductQuantity();
            Assert.IsTrue(CheckMethods.CheckCount(basketProductQuantity, orderProdyctQuantity, WebDriver));
            ReduceProductQuantity();
            Assert.IsTrue(CheckMethods.CheckCount(basketProductQuantity, orderProdyctQuantity, WebDriver));
            BaseMethods.WaitSomeInterval(1);
            DeleteProducts();
        }
    }
}
