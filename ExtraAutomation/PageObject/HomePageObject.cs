using ExtraAutomationTesting;
using OpenQA.Selenium;
using SeleniumHelper.Base;

namespace ExtraAutomation.PageObject
{
    class HomePageObject : BaseClass
    {

        private static string SignInButton = "//span[text()='შესვლა']";
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
