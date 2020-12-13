using ExtraAutomation.PageObject;
using ExtraAutomationTesting;
using NUnit.Framework;
using SeleniumHelper.ComponentHelper;
using SeleniumHelper.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExtraAutomation.TestCases
{
    class PaymantMethodMC : BaseClass
    {
        [Test, Category("Paymant Test Mc")]
        public void PaymantTestMc()
        {
            var signIn = new HomePageObject(WebDriver)
                 .SignIn()
                 .Login();
            CheckOutPageObject.AddProductAndGoToTheCheckoutPage(WebDriver, ElementLocator.Xpath, CheckOutPageObject.PaymentByMc);
            Assert.True(CheckMethods.CheckPaymentMethod(CheckOutPageObject.orderTotalAmount,
               CheckOutPageObject.costOfTheItem, CheckOutPageObject.deliveryCost, WebDriver));
        }
    }
}
