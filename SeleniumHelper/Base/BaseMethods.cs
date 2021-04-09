using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Threading.Tasks;

namespace SeleniumHelper.Base
{
    public static class BaseMethods
    {
        private static IWebElement _webElement;

        public static void ShouldLocate(IWebDriver webDriver, string location)
        {
            try
            {
                new WebDriverWait(webDriver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.UrlContains(location));
            }
            catch (WebDriverTimeoutException ex)
            {
                throw new NotFoundException($"Item not found : {location}", ex);
            }
        }

        public static IWebElement FindElement(IWebDriver webDriver, ElementLocator selector, string element)
        {
            var webElement = webDriver.FindElement(By.XPath(element));
            return webElement;
        }

        public static void WaitSomeInterval(int seconds = 10)
        {
            Task.Delay(TimeSpan.FromSeconds(seconds)).Wait();
        }

        public static IWebElement WaitElementIsVisibleReturn(IWebDriver webDriver, ElementLocator selector,
            string element, int seconds = 15)
        {
            try
            {
                switch (selector)
                {
                    case ElementLocator.Id:
                        _webElement =
                            new WebDriverWait(webDriver, TimeSpan.FromSeconds(seconds)).Until(
                                ExpectedConditions.ElementToBeClickable(By.Id(element)));
                        break;
                    case ElementLocator.Class:
                        _webElement =
                            new WebDriverWait(webDriver, TimeSpan.FromSeconds(seconds)).Until(
                                ExpectedConditions.ElementToBeClickable(By.ClassName(element)));
                        break;
                    case ElementLocator.Xpath:
                        _webElement =
                            new WebDriverWait(webDriver, TimeSpan.FromSeconds(seconds)).Until(
                                ExpectedConditions.ElementToBeClickable(By.XPath(element)));
                        break;
                    case ElementLocator.Name:
                        _webElement =
                            new WebDriverWait(webDriver, TimeSpan.FromSeconds(seconds)).Until(
                                ExpectedConditions.ElementToBeClickable(By.Name(element)));
                        break;
                }

                return _webElement;
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
                new WebDriverWait(webDriver, TimeSpan.FromSeconds(seconds)).Until(
                    ExpectedConditions.ElementIsVisible(By.XPath(element)));
            }
            catch (ElementNotVisibleException ex)
            {
                throw new Exception("Element not Displeed", ex);
            }
        }

        public static void ClickElement(IWebDriver webDriver, ElementLocator selector, string element, int seconds = 30)
        {
            try
            {
                switch (selector)
                {
                    case ElementLocator.Id:
                        new WebDriverWait(webDriver, TimeSpan.FromSeconds(seconds))
                            .Until(ExpectedConditions.ElementToBeClickable(By.Id(element))).Click();
                        break;
                    case ElementLocator.Class:
                        new WebDriverWait(webDriver, TimeSpan.FromSeconds(seconds))
                            .Until(ExpectedConditions.ElementToBeClickable(By.ClassName(element))).Click();
                        break;
                    case ElementLocator.Xpath:
                        new WebDriverWait(webDriver, TimeSpan.FromSeconds(seconds))
                            .Until(ExpectedConditions.ElementToBeClickable(By.XPath(element))).Click();
                        break;
                    case ElementLocator.Name:
                        new WebDriverWait(webDriver, TimeSpan.FromSeconds(seconds))
                            .Until(ExpectedConditions.ElementToBeClickable(By.Name(element))).Click();
                        break;
                }
            }
            catch
            {
                throw new Exception("Failed Element not Visible.");
            }
        }

        //--------------------------------------------------------------
        public static void WaitElementIsVisible(IWebDriver webDriver, ElementLocator selector, string element,
            int seconds = 15)
        {
            try
            {
                switch (selector)
                {
                    case ElementLocator.Id:
                        new WebDriverWait(webDriver, TimeSpan.FromSeconds(seconds)).Until(
                            ExpectedConditions.ElementIsVisible(By.Id(element)));
                        break;
                    case ElementLocator.Class:
                        new WebDriverWait(webDriver, TimeSpan.FromSeconds(seconds)).Until(
                            ExpectedConditions.ElementIsVisible(By.ClassName(element)));
                        break;
                    case ElementLocator.Xpath:
                        new WebDriverWait(webDriver, TimeSpan.FromSeconds(seconds)).Until(
                            ExpectedConditions.ElementIsVisible(By.XPath(element)));
                        break;
                    case ElementLocator.Name:
                        new WebDriverWait(webDriver, TimeSpan.FromSeconds(seconds)).Until(
                            ExpectedConditions.ElementIsVisible(By.Name(element)));
                        break;
                }
            }
            catch
            {
                throw new Exception("Failed Element not Visible.");
            }
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
                }
            }
            catch
            {
                throw new Exception("Failed to send keys.");
            }
        }

        public static IWebElement IwebelementReturn(IWebDriver drv, ElementLocator selector, string element)
        {
            try
            {
                switch (selector)
                {
                    case ElementLocator.Id:
                        _webElement = drv.FindElement(By.Id(element));
                        break;
                    case ElementLocator.Class:
                        _webElement = drv.FindElement(By.ClassName(element));
                        break;
                    case ElementLocator.Xpath:
                        _webElement = drv.FindElement(By.XPath(element));
                        break;
                    case ElementLocator.Name:
                        _webElement = drv.FindElement(By.Name(element));
                        break;
                }

                return _webElement;
            }
            catch
            {
                throw new Exception("Failed to send keys.");
            }
        }
    }
}
