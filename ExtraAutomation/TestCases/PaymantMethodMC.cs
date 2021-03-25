using ExtraAutomation.PageObject;
using NUnit.Framework;
using OpenQA.Selenium;
using QAssistant.Extensions;
using SeleniumHelper.Base;
using SeleniumHelper.ComponentHelper;

namespace ExtraAutomation.TestCases
{
    [TestFixture]
    class PaymantMethodMC : CheckOutPageObject
    {
        [Test, Category("Paymant Test Mc")]
        public static void PaymantTestMc()
        {
            AuthorizationPageObject.SigninFullMethod();
            AddProductAndGoToTheCheckoutPage(WebDriver, ElementLocator.Xpath, PaymentByMc);
            Assert.True(CheckMethods.CheckPaymentMethod(orderTotalAmount, costOfTheItem, deliveryCost, WebDriver));
            WebDriver.Click(By.XPath(OrderCompleteButton));

        }
    }
}
