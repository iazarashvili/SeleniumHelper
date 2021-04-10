using ExtraAutomation.PageObject;
using NUnit.Framework;
using SeleniumHelper.Base;

namespace ExtraAutomation.TestCases
{
    [TestFixture]
    class PaymentMethodIPay : CheckOutPageObject
    {
        [Test, Category("Paymant Test Ipay")]
        public static void PaymantTestIpay()
        {
            AuthorizationPageObject.SigninFullMethod();
            AddProductAndGoToTheCheckoutPage(WebDriver, ElementLocator.Xpath, paymentByCardIpay);
            Assert.True(CheckMethods.CheckPaymentMethod(orderTotalAmount, costOfTheItem, deliveryCost, WebDriver));
            BaseMethods.ClickElement(WebDriver, ElementLocator.Xpath, orderCompleteButton);

        }
    }
}
