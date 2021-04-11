using OpenQA.Selenium;
using QAssistant.Extensions;
using System;


namespace ExtraAutomation.PageObject
{
    public class AuthorizationPageObject : BaseClass
    {

        private const string LoginInputField = "//input[@placeholder='ტელეფონი ან ელ.ფოსტა']";
        private const string PasswordInputField = "//input[@placeholder='პაროლი']";
        protected const string LoginButton = "//span[text()=' შესვლა']";
        protected const string CheckedLocator = "//span[contains(text(),' ilia')]";

        //public static readonly string EnterUserNameMethod = "walih51209@wedbo.net";
        //public static readonly string enterPassword = "Extra2222";
        protected const string EnterPassword = "Extra2020";
        protected const string EnterUserName = "tapey73486@yutongdt.com";

        protected const string ValidLoginEnterWrongPass = "//span[@class='_s_color-red _s_label _s_label-xs']";

        public static void EnterUserNameMethod(string username)
        {
            try
            {
                WebDriver.WaitUntilFindElement(By.XPath(LoginInputField)).SendKeys(username);
            }
            catch (NotFoundException ex)
            {
                Console.WriteLine("Element Not Found" + ex.Message);
            }
        }
        public static void EnterPasswordMethod(string password)
        {
            try
            {
                WebDriver.WaitUntilFindElement(By.XPath(PasswordInputField)).SendKeys(password);
            }
            catch (NotFoundException ex)
            {
                Console.WriteLine("Element Not Found" + ex.Message);
            }

        }

        public static void SigninFullMethod()
        {
            HomePageObject.SignIn();
            EnterUserNameMethod(EnterUserName);
            EnterPasswordMethod(EnterPassword);
            WebDriver.Click(By.XPath(LoginButton));
        }

    }

}
