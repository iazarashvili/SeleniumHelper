using OpenQA.Selenium;
using QAssistant.Extensions;
using System;


namespace ExtraAutomation.PageObject
{
    public class AuthorizationPageObject : BaseClass
    {

        private static readonly string loginInputField = "//input[@placeholder='ტელეფონი ან ელ.ფოსტა']";
        private static readonly string passwordInputField = "//input[@placeholder='პაროლი']";
        public static readonly string logginButton = "//span[text()=' შესვლა']";
        public static readonly string checkedlocator = "//span[contains(text(),' ilia')]";

        //public static readonly string enterUserName = "walih51209@wedbo.net";
        //public static readonly string enterPassword = "Extra2222";
        public static readonly string enterPassword = "Extra2020";
        public static readonly string enterUserName = "tapey73486@yutongdt.com";

        public static readonly string validLoginEnterWrongPass = "//span[@class='_s_color-red _s_label _s_label-xs']";

        public static void EnterUserName(string username)
        {
            try
            {
                WebDriver.WaitUntilFindElement(By.XPath(loginInputField)).SendKeys(username);
            }
            catch (NotFoundException ex)
            {
                Console.WriteLine("Element Not Found" + ex.Message);
            }
        }
        public static void EnterPassword(string password)
        {
            try
            {
                WebDriver.WaitUntilFindElement(By.XPath(passwordInputField)).SendKeys(password);
            }
            catch (NotFoundException ex)
            {
                Console.WriteLine("Element Not Found" + ex.Message);
            }

        }

        public static void SigninFullMethod()
        {
            HomePageObject.SignIn();
            EnterUserName(enterUserName);
            EnterPassword(enterPassword);
            WebDriver.Click(By.XPath(logginButton));
        }

    }

}
