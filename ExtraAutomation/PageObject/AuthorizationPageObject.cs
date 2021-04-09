using OpenQA.Selenium;
using QAssistant.Extensions;


namespace ExtraAutomation.PageObject
{
    public class AuthorizationPageObject : BaseClass
    {

        private static readonly string LoginInputField = "//input[@placeholder='ტელეფონი ან ელ.ფოსტა']";
        private static readonly string PasswordInputField = "//input[@placeholder='პაროლი']";
        public static readonly string LogginButton = "//span[text()=' შესვლა']";
        public static readonly string checkedlocator = "//span[contains(text(),' ilia')]";

        //public static readonly string enterUserName = "walih51209@wedbo.net";
        //public static readonly string enterPassword = "Extra2222";
        public static readonly string enterPassword = "Extra2020";
        public static readonly string enterUserName = "tapey73486@yutongdt.com";

        public static readonly string ValidLoginEnterWrongPass = "//span[@class='_s_color-red _s_label _s_label-xs']";

        public static void EnterUserName(string username)
        {
            WebDriver.WaitUntilFindElement(By.XPath(LoginInputField)).SendKeys(username);
        }
        public static void EnterPassword(string password)
        {
            WebDriver.WaitUntilFindElement(By.XPath(PasswordInputField)).SendKeys(password);
        }

        public static void SigninFullMethod()
        {
            HomePageObject.SignIn();
            EnterUserName(enterUserName);
            EnterPassword(enterPassword);
            WebDriver.Click(By.XPath(LogginButton));
        }

    }

}
