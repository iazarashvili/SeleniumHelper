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
            AddProductAndGoToTheCheckoutPage(WebDriver, ElementLocator.Xpath, PaymentByCourier);
            Assert.True(CheckMethods.CheckPaymentMethod(OrderTotalAmount,
               CostOfTheItem, DeliveryCost, WebDriver));
        }
    }
}
