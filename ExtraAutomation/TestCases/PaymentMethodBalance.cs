using ExtraAutomation.PageObject;
using ExtraAutomationTesting;
using NUnit.Framework;
using SeleniumHelper.Base;
using SeleniumHelper.ComponentHelper;

namespace ExtraAutomation.TestCases
{
    [TestFixture]
    class PaymentMethodBalance : BaseClass
    {
      
        [Test, Category("Paymant Test Balance")]
        public void PaymantTestBalance()
        {
            var signIn = new HomePageObject(WebDriver)
                .SignIn()
                .Login();

            CheckOutPageObject.AddProductAndGoToTheCheckoutPage(WebDriver, ElementLocator.Xpath, CheckOutPageObject.PaymentByBalance);
           Assert.True(CheckMethods.CheckPaymentMethod(CheckOutPageObject.orderTotalAmount,
               CheckOutPageObject.costOfTheItem, CheckOutPageObject.deliveryCost, WebDriver));
            BaseMethods.ClickElement(WebDriver, ElementLocator.Xpath, CheckOutPageObject.OrderCompleteButton);
        }
    }
}
