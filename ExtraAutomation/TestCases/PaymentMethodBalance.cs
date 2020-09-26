using ExtraAutomationTesting;
using SingularQATestService;
using SeleniumHelper.Base;
using NUnit.Framework;
using System.Threading;

namespace ExtraAutomation.TestCases
{
    [TestFixture]
    class PaymentMethodBalance : BaseClass
    {
      
        [Test, Category("Paymant Test Balance")]
        public void PaymantTestBalance()
        {
            var login = new Login(WebDriver);
            login.TestLogin();
            BaseMethods.SendKeys(WebDriver, ElementLocator.Xpath, PaymentsLocators.SearchInput, "80509");
            BaseMethods.Click(WebDriver, ElementLocator.Xpath, PaymentsLocators.SearchButton);

            Thread.Sleep(500);
            BaseMethods.Click(WebDriver, ElementLocator.Xpath, PaymentsLocators.addProductButton);

            Thread.Sleep(500);
            BaseMethods.Click(WebDriver, ElementLocator.Xpath, PaymentsLocators.getBasket);

            BaseMethods.WaitToBeClickable(WebDriver, ElementLocator.Xpath, PaymentsLocators.shopButton);
            BaseMethods.Click(WebDriver, ElementLocator.Xpath, PaymentsLocators.shopButton);

        }
    }
}
