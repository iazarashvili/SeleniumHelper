using ExtraAutomation.PageObject;
using NUnit.Framework;
using OpenQA.Selenium;
using QAssistant.Extensions;
using SeleniumHelper.Base;

namespace ExtraAutomation.TestCases
{
    [TestFixture]
    class PaymantMethodPlusPoints : CheckOutPageObject
    {

        [Test, Category("Paymant Test PlusPoints")]
        public static void PaymantPlusPoint()
        {
            AuthorizationPageObject.SigninFullMethod();
            AddProductAndGoToTheCheckoutPage(WebDriver, ElementLocator.Xpath, paymentByPlusPoint);
            Assert.True(CheckMethods.CheckPaymentMethod(orderTotalAmount,
                costOfTheItem, deliveryCost, WebDriver));
            WebDriver.WaitUntilFindElement(By.XPath(orderCompleteButton)).Click();

        }
    }
}
