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
    }
}