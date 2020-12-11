using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumHelper.Base;
using System.Threading;

namespace ExtraAutomation
{
    public class PaymentTestHelpMethods
    {
        public static void GetCheckoutPage(IWebDriver WebDriver)
        {
            BaseMethods.SendKeys(WebDriver, ElementLocator.Xpath, PaymentsLocators.SearchKeywordInputField, "11125");
            BaseMethods.ClickElement(WebDriver, ElementLocator.Xpath, PaymentsLocators.SearchButton);

            Thread.Sleep(500);
            BaseMethods.ClickElement(WebDriver, ElementLocator.Xpath, PaymentsLocators.addProductButton);

            Thread.Sleep(500);
            BaseMethods.ClickElement(WebDriver, ElementLocator.Xpath, PaymentsLocators.getBasket);

            BaseMethods.ClickElement(WebDriver, ElementLocator.Xpath, PaymentsLocators.shopButton);
        }

      
    }
}
