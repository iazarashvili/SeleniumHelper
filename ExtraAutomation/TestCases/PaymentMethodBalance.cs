using ExtraAutomation.PageObject;
using NUnit.Framework;
using SeleniumHelper.Base;

namespace ExtraAutomation.TestCases
{
    [TestFixture]
    class PaymentMethodBalance : CheckOutPageObject
    {

        [Test, Category("Paymant Test Balance")]
        public static void PaymantTestBalance()
        {
            AuthorizationPageObject.SigninFullMethod();
            AddProductAndGoToTheCheckoutPage(WebDriver, ElementLocator.Xpath, paymentByBalance);
            Assert.True(CheckMethods.CheckPaymentMethod(orderTotalAmount, costOfTheItem, deliveryCost, WebDriver));
            BaseMethods.ClickElement(WebDriver, ElementLocator.Xpath, orderCompleteButton);
        }
    }
}
