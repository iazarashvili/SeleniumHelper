using ExtraAutomation.PageObject;
using NUnit.Framework;
using OpenQA.Selenium;
using QAssistant.Extensions;
using SeleniumHelper.Base;
using SeleniumHelper.ComponentHelper;

namespace ExtraAutomation.TestCases
{
    [TestFixture]
    class PaymantMethodPlusPoints : CheckOutPageObject
    {

        [Test, Category("Paymant Test PlusPoints")]
        public static void PaymantPlusPoint()
        {
            AuthorizationPageObject.SigninFullMethod();
            AddProductAndGoToTheCheckoutPage(WebDriver, ElementLocator.Xpath, PaymentByPlusPoint);
            Assert.True(CheckMethods.CheckPaymentMethod(orderTotalAmount,
                costOfTheItem, deliveryCost, WebDriver));
            WebDriver.WaitUntilFindElement(By.XPath(OrderCompleteButton)).Click();

        }
    }
}
