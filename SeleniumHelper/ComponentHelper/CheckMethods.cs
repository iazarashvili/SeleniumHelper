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
        public static bool CheckCount(By first, By last , IWebDriver WebDriver)
        {
            IWebElement cartCount = WebDriver.FindElement(first);
            IWebElement orderCount = WebDriver.FindElement(last);
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