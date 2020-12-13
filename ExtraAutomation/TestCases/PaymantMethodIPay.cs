﻿using ExtraAutomation.PageObject;
using ExtraAutomationTesting;
using NUnit.Framework;
using SeleniumHelper.ComponentHelper;

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
            CheckOutPageObject.AddProductAndGoToTheCheckoutPage(WebDriver);
            Assert.True(CheckMethods.CheckPaymentMethod(CheckOutPageObject.orderTotalAmount,
               CheckOutPageObject.costOfTheItem, CheckOutPageObject.deliveryCost, WebDriver));
        }
    }
}
