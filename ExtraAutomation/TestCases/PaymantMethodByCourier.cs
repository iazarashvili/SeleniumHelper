using ExtraAutomation.PageObject;
using NUnit.Framework;
using SeleniumHelper.Base;


namespace ExtraAutomation.TestCases
{
    [TestFixture]
    class PaymantMethodByCourier : CheckOutPageObject
    {
        [Test, Category("Paymant Test By Courier")]
        public static void PaymantTestCash()
        {
            AuthorizationPageObject.SigninFullMethod();
            AddProductAndGoToTheCheckoutPage(WebDriver, ElementLocator.Xpath, paymentByCourier);
            Assert.True(CheckMethods.CheckPaymentMethod(orderTotalAmount,
               costOfTheItem, deliveryCost, WebDriver));
        }
    }
}
