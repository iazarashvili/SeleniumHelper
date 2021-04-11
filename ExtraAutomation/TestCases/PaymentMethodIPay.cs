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
            AddProductAndGoToTheCheckoutPage(WebDriver, ElementLocator.Xpath, PaymentByCardIpay);
            Assert.True(CheckMethods.CheckPaymentMethod(OrderTotalAmount, CostOfTheItem, DeliveryCost, WebDriver));
            BaseMethods.ClickElement(WebDriver, ElementLocator.Xpath, OrderCompleteButton);

        }
    }
}
