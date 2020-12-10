using ExtraAutomationTesting;
using NUnit.Framework;
using ExtraAutomation;
using System;
using ExtraAutomation.PageObject;

namespace ExtraAutomation.TestCases
{
    [TestFixture]
    class PaymantMethodIPay : BaseClass
    {  
        [Test,Category("Paymant Test Ipay")]
        public void PaymantTestIpay()
        {
            var signIn = new HomePageObject(WebDriver)
                 .SignIn()
                 .Login();
            PaymentTestHelpMethods.GetCheckoutPage(WebDriver);
        }
    }
}
