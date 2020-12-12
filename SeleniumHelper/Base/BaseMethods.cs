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

        public static IWebElement findElement(IWebDriver webDriver, ElementLocator selector, string element)
        {
            IWebElement webElement = webDriver.FindElement(By.XPath(element));
            return webElement;
        }

        public static void WaitSomeInterval(int seconds = 10)
        {
            Task.Delay(TimeSpan.FromSeconds(seconds)).Wait();
        }

        public static IWebElement WaitElementIsVisibleReturn(IWebDriver webDriver, ElementLocator selector, string element, int seconds = 15)
        {
            try
            {
                switch (selector)
                {
                    case ElementLocator.Id:
                        webElement =  new WebDriverWait(webDriver, TimeSpan.FromSeconds(seconds)).Until(ExpectedConditions.ElementToBeClickable(By.Id(element)));
                        break;
                    case ElementLocator.Class:
                       webElement = new WebDriverWait(webDriver, TimeSpan.FromSeconds(seconds)).Until(ExpectedConditions.ElementToBeClickable(By.ClassName(element)));
                        break;
                    case ElementLocator.Xpath:
                       webElement =  new WebDriverWait(webDriver, TimeSpan.FromSeconds(seconds)).Until(ExpectedConditions.ElementToBeClickable(By.XPath(element)));
                        break;
                    case ElementLocator.Name:
                        webElement = new WebDriverWait(webDriver, TimeSpan.FromSeconds(seconds)).Until(ExpectedConditions.ElementToBeClickable(By.Name(element)));
                        break;
                    default:
                        break;
                }
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

        //--------------------------------------------------------------
        public static void WaitElementIsVisible(IWebDriver webDriver, ElementLocator selector, string element, int seconds = 15)
        {
            try
            {
                switch (selector)
                {
                    case ElementLocator.Id:
                        new WebDriverWait(webDriver, TimeSpan.FromSeconds(seconds)).Until(ExpectedConditions.ElementIsVisible(By.Id(element)));
                        break;
                    case ElementLocator.Class:
                        new WebDriverWait(webDriver, TimeSpan.FromSeconds(seconds)).Until(ExpectedConditions.ElementIsVisible(By.ClassName(element)));
                        break;
                    case ElementLocator.Xpath:
                        new WebDriverWait(webDriver, TimeSpan.FromSeconds(seconds)).Until(ExpectedConditions.ElementIsVisible(By.XPath(element)));
                        break;
                    case ElementLocator.Name:
                        new WebDriverWait(webDriver, TimeSpan.FromSeconds(seconds)).Until(ExpectedConditions.ElementIsVisible(By.Name(element)));
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

        public static IWebElement IwebelementReturn(IWebDriver drv, ElementLocator selector, string element)
        {            
            try
            {
                switch (selector)
                {
                    case ElementLocator.Id:
                      webElement = drv.FindElement(By.Id(element));
                        break;
                    case ElementLocator.Class:
                        webElement = drv.FindElement(By.ClassName(element));
                        break;
                    case ElementLocator.Xpath:
                        webElement = drv.FindElement(By.XPath(element));
                        break;
                    case ElementLocator.Name:
                        webElement = drv.FindElement(By.Name(element));
                        break;
                    default:
                        break;
                }
                return webElement;
            }
            catch { throw new Exception("Failed to send keys."); }
        }
    }
}
