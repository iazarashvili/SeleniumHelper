using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumHelper.Base;

namespace SingularQATestService
{
    public class BaseMethods
    {
        private static IWebElement webElement;
        public static void Click(IWebDriver drv, ElementLocator selector, string element)
        {
            var action = new Actions(drv);
            try
            {
                IWebElement iWebElement;
                switch (selector)
                {
                    case ElementLocator.Id:
                        iWebElement = drv.FindElement(By.Id(element));
                        action.MoveToElement(iWebElement).Click().Perform();
                        break;
                    case ElementLocator.Class:
                        iWebElement = drv.FindElement(By.ClassName(element));
                        action.MoveToElement(iWebElement).Click().Perform();
                        break;
                    case ElementLocator.Xpath:
                        iWebElement = drv.FindElement(By.XPath(element));
                        action.MoveToElement(iWebElement).Click().Perform();
                        break;
                    case ElementLocator.Name:
                        iWebElement = drv.FindElement(By.Name(element));
                        action.MoveToElement(iWebElement).Click().Perform();
                        break;
                    default:
                        break;
                }
            }
            catch (Exception e) { throw new Exception($"Failed to click on element. \r\nException Message: {e.Message}"); }
        }
        
        public static void SendKeys(IWebDriver drv, ElementLocator selector, string element, string text)
        {
            try
            {
                switch (selector)
                {
                    case ElementLocator.Id:
                        drv.FindElement(By.Id(element)).SendKeys(text);
                        break;
                    case ElementLocator.Class:
                        drv.FindElement(By.ClassName(element)).SendKeys(text);
                        break;
                    case ElementLocator.Xpath:
                        drv.FindElement(By.XPath(element)).SendKeys(text);
                        break;
                    case ElementLocator.Name:
                        drv.FindElement(By.Name(element)).SendKeys(text);
                        break;
                    default:
                        break;
                }
            }
            catch { throw new Exception("Failed to send keys."); }
        }
        
        public static bool Wait(IWebDriver drv, ElementLocator selector, string element, int seconds = 15)
        {
            var wait = new WebDriverWait(drv, TimeSpan.FromSeconds(seconds));
            try
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(element)));
                return true;
            }
            catch (ElementNotVisibleException ex)
            {
                Console.WriteLine($"Element {element} wasn't found. Exception Message: {ex.Message}");
                return false;
            }
        }
        public static bool WaitToBeClickable(IWebDriver drv, ElementLocator selector, string element, int seconds = 15)
        {
            var wait = new WebDriverWait(drv, TimeSpan.FromSeconds(seconds));
            try
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(element)));
                return true;
            }
            catch (ElementNotVisibleException ex)
            {
                Console.WriteLine($"Element {element} wasn't found. Exception Message: {ex.Message}");
                return false;
            }
        }
        public static IWebElement WaitTillElementDisplayed(IWebDriver driver, string locator,  ElementLocator elementLocatorType = ElementLocator.Xpath, int TimeOutForFindingElement = 15)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(TimeOutForFindingElement));

            if (elementLocatorType == ElementLocator.Xpath)
            {
                webElement = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(locator)));
            }
            else if (elementLocatorType == ElementLocator.Class)
            {
                webElement = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.PartialLinkText(locator)));
            }
            else if (elementLocatorType == ElementLocator.Name)
            {
                webElement = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Name(locator)));
            }
            else if (elementLocatorType == ElementLocator.Id)
            {
                webElement = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.LinkText(locator)));
            }
            else if (elementLocatorType == ElementLocator.Id)
            {
                webElement = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id(locator)));
            }
            return webElement;
        }

       
        
    }
}