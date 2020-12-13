using ExtraAutomation.PageObject;
using ExtraAutomationTesting;
using NUnit.Framework;
using SeleniumHelper.ComponentHelper;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExtraAutomation.TestCases
{
    class PaymantMethodByCourier : BaseClass
    {
        [Test, Category("Paymant Test By Courier")]
        public void PaymantTestCash()
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
