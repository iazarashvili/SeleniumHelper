using ExtraAutomation.PageObject;
using NUnit.Framework;
using SeleniumHelper.Base;
using SeleniumHelper.ComponentHelper;


namespace ExtraAutomation.TestCases
{
    [TestFixture]
    class PaymantMethodByCourier : CheckOutPageObject
    {
        [Test, Category("Paymant Test By Courier")]
        public static void PaymantTestCash()
        {
            AuthorizationPageObject.SigninFullMethod();
            AddProductAndGoToTheCheckoutPage(WebDriver, ElementLocator.Xpath, PaymentByCourier);
            Assert.True(CheckMethods.CheckPaymentMethod(orderTotalAmount,
               costOfTheItem, deliveryCost, WebDriver));
        }
    }
}
