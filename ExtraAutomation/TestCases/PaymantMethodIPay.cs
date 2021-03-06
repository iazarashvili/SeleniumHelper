using ExtraAutomation.PageObject;
using ExtraAutomationTesting;
using NUnit.Framework;
using SeleniumHelper.Base;
using SeleniumHelper.ComponentHelper;

namespace ExtraAutomation.TestCases
{
    [TestFixture]
    class PaymantMethodIPay : BaseClass
    {
        [Test, Category("Paymant Test Ipay")]
        public void PaymantTestIpay()
        {
            var signIn = new HomePageObject(WebDriver)
                 .SignIn()
                 .Login();
            CheckOutPageObject.AddProductAndGoToTheCheckoutPage(WebDriver, ElementLocator.Xpath, CheckOutPageObject.PaymentByCardIpay);
            Assert.True(CheckMethods.CheckPaymentMethod(CheckOutPageObject.orderTotalAmount,
               CheckOutPageObject.costOfTheItem, CheckOutPageObject.deliveryCost, WebDriver));
            BaseMethods.ClickElement(WebDriver, ElementLocator.Xpath, CheckOutPageObject.OrderCompleteButton);

        }
    }
}
