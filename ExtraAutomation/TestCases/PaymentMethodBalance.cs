using ExtraAutomationTesting;
using NUnit.Framework;
using SeleniumHelper.ComponentHelper;
using System.Threading;
using System;
using ExtraAutomation.PageObject;

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

            PaymentTestHelpMethods.GetCheckoutPage(WebDriver);

           Assert.True(CheckMethods.CheckPaymentMethod(PaymentsLocators.orderTotalAmount,
               PaymentsLocators.costOfTheItem, PaymentsLocators.deliveryCost, WebDriver));
        }
    }
}
