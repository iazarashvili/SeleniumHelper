using System;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using SeleniumHelper.Base;

namespace SeleniumHelper.Base
{
    public static class BaseMethods
    {
        private static IWebElement webElement;
        
        public static void ShouldLocate(IWebDriver webDriver, string location)
        {
            try
            {
                new WebDriverWait(webDriver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.UrlContains(location));
            }
            catch (WebDriverTimeoutException ex)
            {

                throw new NotFoundException($"Cannot find out that app in specific lovalion : {location}", ex);
            }
        }

        public static void WaitSomeInterval(int seconds = 10)
        {
            Task.Delay(TimeSpan.FromSeconds(seconds)).Wait();
        }

        public static IWebElement WaitElement(IWebDriver webDriver, ElementLocator selector, string element, int seconds = 15)
        {
            try
            {
                
                webElement = new WebDriverWait(webDriver, TimeSpan.FromSeconds(seconds)).Until(ExpectedConditions.ElementIsVisible(By.XPath(element)));
                return webElement;
            }
            catch (Exception ex)
            {

                throw new Exception("Failed Element not Visible.", ex);
            }
         
        }

        public static void WaitDispleed(IWebDriver webDriver, ElementLocator selector, string element, int seconds = 15)
        {
            try
            {
                new WebDriverWait(webDriver, TimeSpan.FromSeconds(seconds)).Until(ExpectedConditions.ElementIsVisible(By.XPath(element)));
            }
            catch (ElementNotVisibleException ex)
            {
                throw new Exception("Element not Displeed", ex);
            }
           
        }

        public static void ClickElement(IWebDriver webDriver, ElementLocator selector, string element, int seconds = 15)
        {
            try
            {
                switch (selector)
                {
                    case ElementLocator.Id:
                        new WebDriverWait(webDriver, TimeSpan.FromSeconds(seconds)).Until(ExpectedConditions.ElementToBeClickable(By.Id(element))).Click();
                        break;
                    case ElementLocator.Class:
                        new WebDriverWait(webDriver, TimeSpan.FromSeconds(seconds)).Until(ExpectedConditions.ElementToBeClickable(By.ClassName(element))).Click();
                        break;
                    case ElementLocator.Xpath:
                        new WebDriverWait(webDriver, TimeSpan.FromSeconds(seconds)).Until(ExpectedConditions.ElementToBeClickable(By.XPath(element))).Click();
                        break;
                    case ElementLocator.Name:
                        new WebDriverWait(webDriver, TimeSpan.FromSeconds(seconds)).Until(ExpectedConditions.ElementToBeClickable(By.Name(element))).Click();
                        break;
                    default:
                        break;
                }
            }
            catch { throw new Exception("Failed Element not Visible."); }
        }

        // -------- - - - - - - - -- -  --  -  - - - - - - - - - -

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

        // - - ------ - - - - - - - - ----------------------------------------------------------
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
                webElement = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(locator)));
            }
            else if (elementLocatorType == ElementLocator.Class)
            {
                webElement = wait.Until(ExpectedConditions.ElementIsVisible(By.PartialLinkText(locator)));
            }
            else if (elementLocatorType == ElementLocator.Name)
            {
                webElement = wait.Until(ExpectedConditions.ElementIsVisible(By.Name(locator)));
            }
            else if (elementLocatorType == ElementLocator.Id)
            {
                webElement = wait.Until(ExpectedConditions.ElementIsVisible(By.LinkText(locator)));
            }
            return webElement;
        }
    }
}