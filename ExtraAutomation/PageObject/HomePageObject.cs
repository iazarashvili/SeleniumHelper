using OpenQA.Selenium;
using QAssistant.Extensions;
using SeleniumHelper.Base;

namespace ExtraAutomation.PageObject
{
    public class HomePageObject : BaseClass
    {

        private static readonly string signInButton = "//span[text()='შესვლა']";

        public static void SignIn()
        {
            BaseMethods.WaitSomeInterval(2);
            WebDriver.Click(By.XPath(signInButton));
        }

    }
}
