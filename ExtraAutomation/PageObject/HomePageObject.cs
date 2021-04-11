using OpenQA.Selenium;
using QAssistant.Extensions;
using SeleniumHelper.Base;

namespace ExtraAutomation.PageObject
{
    public class HomePageObject : BaseClass
    {

        private const string SignInButton = "//span[text()='შესვლა']";

        public static void SignIn()
        {
            BaseMethods.WaitSomeInterval(2);
            WebDriver.Click(By.XPath(SignInButton));
        }

    }
}
