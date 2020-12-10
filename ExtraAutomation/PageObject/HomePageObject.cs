using ExtraAutomationTesting;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumHelper.Base;
using SeleniumHelper.ComponentHelper;
using System.Threading;

namespace ExtraAutomation.PageObject
{
    class HomePageObject : BaseClass
    {
        private IWebDriver _webdriver;

        public static string SignInButton = "//span[text()='შესვლა']";
        public HomePageObject(IWebDriver webDriver)
        {
            _webdriver = webDriver;
        }

        public AuthorizationPageObject SignIn()
        {
            if (BaseMethods.WaitToBeClickable(_webdriver, ElementLocator.Xpath, SignInButton, 12))
            {
                BaseMethods.Click(_webdriver, ElementLocator.Xpath, SignInButton);
            }
            return new AuthorizationPageObject(_webdriver);
        }
    }
}
