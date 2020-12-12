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

        public static string SignInButton = "//span[text()='შესვლა']";
        public HomePageObject(IWebDriver webDriver)
        {
            WebDriver = webDriver;
        }

        public AuthorizationPageObject SignIn()
        {
            BaseMethods.WaitSomeInterval(2);
            BaseMethods.ClickElement(WebDriver, ElementLocator.Xpath, SignInButton);
            return new AuthorizationPageObject(WebDriver);
        }
    }
}
