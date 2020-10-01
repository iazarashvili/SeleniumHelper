using ExtraAutomationTesting;
using SingularQATestService;
using SeleniumHelper.Base;
using NUnit.Framework;
using System.Threading;
using SeleniumHelper.ComponentHelper;

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

            Thread.Sleep(700);
            BaseMethods.Click(WebDriver, ElementLocator.Xpath, PaymentsLocators.addProductButton);

            Thread.Sleep(500);
            BaseMethods.Click(WebDriver, ElementLocator.Xpath, PaymentsLocators.getBasket);

            BaseMethods.WaitToBeClickable(WebDriver, ElementLocator.Xpath, PaymentsLocators.shopButton);
            BaseMethods.Click(WebDriver, ElementLocator.Xpath, PaymentsLocators.shopButton);

           Assert.True(CheckMethods.CheckMoney(PaymentsLocators.orderTotalAmount, PaymentsLocators.costOfTheItem, PaymentsLocators.deliveryCost, WebDriver));

        }
    }
}
