using ExtraAutomationTesting;
using NUnit.Framework;
using ExtraAutomation;
using System;
namespace ExtraAutomation.TestCases
{
    [TestFixture]
    class PaymantMethodIPay : BaseClass
    {
        
       [Test,Category("Paymant Test Ipay")]
        public void PaymantTestIpay()
        {
            var login = new Login(WebDriver);
            login.TestLogin();
            //BaseMethods.SendKeys(WebDriver, ElementLocator.Xpath, PaymentsLocators.SearchKeywordInputField, "80509");
            //BaseMethods.Click(WebDriver, ElementLocator.Xpath, PaymentsLocators.SearchButton);

            //Thread.Sleep(500);
            //BaseMethods.Click(WebDriver, ElementLocator.Xpath, PaymentsLocators.addProductButton);

            //Thread.Sleep(500);
            //BaseMethods.Click(WebDriver, ElementLocator.Xpath, PaymentsLocators.getBasket);

            //BaseMethods.WaitToBeClickable(WebDriver, ElementLocator.Xpath, PaymentsLocators.shopButton);
            //BaseMethods.Click(WebDriver, ElementLocator.Xpath, PaymentsLocators.shopButton);
            PaymentTestHelpMethods.GetCheckoutPage(WebDriver);
        }
    }
}
