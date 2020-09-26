using System;
using OpenQA.Selenium;
using SeleniumHelper.Base;
using SingularQATestService;

namespace SeleniumHelper.ComponentHelper
{
    public class CheckMethods
    {
        public static bool CheckValidLogin(IWebDriver driver, string locator)
        {
            try
            {
                BaseMethods.WaitTillElementDisplayed(driver, locator, ElementLocator.Xpath);
                return true;
            }
            catch (NotFoundException e)
            {
                Console.WriteLine("Username not ound" , e);
                return false;
            }
        }
        public static bool CheckCount(string first, string last , IWebDriver WebDriver)
        {
            IWebElement cartCount = BaseMethods.WaitElement(WebDriver, ElementLocator.Xpath, first);
            IWebElement orderCount = BaseMethods.WaitElement(WebDriver, ElementLocator.Xpath, last);
            int cartNumber = int.Parse(cartCount.Text);
            int orderNumber = int.Parse(orderCount.Text);
            if (cartNumber == orderNumber)
            {
                return true;
            }
            return false;
        }
    }
}