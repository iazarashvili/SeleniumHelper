using ExtraAutomationTesting;
using NUnit.Framework;
using SeleniumHelper.ComponentHelper;
using System.Threading;
using System;

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
            //BaseMethods.SendKeys(WebDriver, ElementLocator.Xpath, PaymentsLocators.SearchKeywordInputField, "80509");
            //BaseMethods.Click(WebDriver, ElementLocator.Xpath, PaymentsLocators.SearchButton);

            //Thread.Sleep(700);
            //BaseMethods.Click(WebDriver, ElementLocator.Xpath, PaymentsLocators.addProductButton);

            //Thread.Sleep(500);
            //BaseMethods.Click(WebDriver, ElementLocator.Xpath, PaymentsLocators.getBasket);

            //BaseMethods.WaitToBeClickable(WebDriver, ElementLocator.Xpath, PaymentsLocators.shopButton);
            //BaseMethods.Click(WebDriver, ElementLocator.Xpath, PaymentsLocators.shopButton);
            PaymentTestHelpMethods.GetCheckoutPage(WebDriver);

           Assert.True(CheckMethods.CheckPaymentMethod(PaymentsLocators.orderTotalAmount, PaymentsLocators.costOfTheItem, PaymentsLocators.deliveryCost, WebDriver));
            Thread.Sleep(500);
        }
    }
}
