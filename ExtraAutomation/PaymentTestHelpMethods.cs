using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumHelper.Base;
using SingularQATestService;
using System.Threading;

namespace ExtraAutomation
{
    public class PaymentTestHelpMethods
    {
        public static void GetCheckoutPage(IWebDriver WebDriver)
        {
            BaseMethods.SendKeys(WebDriver, ElementLocator.Xpath, PaymentsLocators.SearchKeywordInputField, "11125");
            BaseMethods.Click(WebDriver, ElementLocator.Xpath, PaymentsLocators.SearchButton);

            Thread.Sleep(500);
            BaseMethods.Click(WebDriver, ElementLocator.Xpath, PaymentsLocators.addProductButton);

            Thread.Sleep(500);
            BaseMethods.Click(WebDriver, ElementLocator.Xpath, PaymentsLocators.getBasket);

            BaseMethods.WaitToBeClickable(WebDriver, ElementLocator.Xpath, PaymentsLocators.shopButton);
            BaseMethods.Click(WebDriver, ElementLocator.Xpath, PaymentsLocators.shopButton);
        }

        public static void ClosePopup(IWebDriver webDriver)
        {
            BaseMethods.Click(webDriver, ElementLocator.Xpath, PaymentsLocators.Popup);
        }
    }
}
