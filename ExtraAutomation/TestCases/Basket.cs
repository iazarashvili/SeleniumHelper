using ExtraAutomation.PageObject;
using NUnit.Allure.Core;
using NUnit.Framework;
using SeleniumHelper.Base;

namespace ExtraAutomation.TestCases
{
    [AllureNUnit]
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
