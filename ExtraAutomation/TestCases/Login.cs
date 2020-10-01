using ExtraAutomationTesting;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumHelper.Base;
using SeleniumHelper.ComponentHelper;
using SingularQATestService;
using System;

namespace ExtraAutomation.TestCases
{

    public class Login : BaseClass
    {
        public static string HostUrl = "https://extra.ge";
        public static string MyEmail = "595300019";
        public static string MyPassword = "extra2020";
        public static string SignInButton = "//span[text()='შესვლა']";
        private static string checkedlocator = "//span[contains(text(),'test ')]";


        public static string LoginInputButton = "//input[@placeholder='ტელეფონი ან ელ.ფოსტა']";
        public static string PasswordInput = "//input[@placeholder='პაროლი']";
        public static string LogginButton = "//app-sign-in-page//button[text()=' შესვლა ']";
  
        public void TestLogin()
        {
            try
            {
                if (BaseMethods.WaitToBeClickable(WebDriver, ElementLocator.Xpath, SignInButton))
                {
                    BaseMethods.Click(WebDriver, ElementLocator.Xpath, SignInButton);
                    if (BaseMethods.Wait(WebDriver, ElementLocator.Xpath, LoginInputButton) &&
                        BaseMethods.Wait(WebDriver, ElementLocator.Xpath, PasswordInput))
                    {

                        BaseMethods.SendKeys(WebDriver, ElementLocator.Xpath, LoginInputButton, MyEmail);
                        BaseMethods.SendKeys(WebDriver, ElementLocator.Xpath, PasswordInput, MyPassword);
                        BaseMethods.Click(WebDriver, ElementLocator.Xpath, LogginButton);
                        Assert.IsTrue(CheckMethods.CheckValidLogin(WebDriver, checkedlocator));
                    }
                }

                else
                {
                    Console.WriteLine("Login Test Failed.");
                    Console.WriteLine("UsernameField, PasswordField or LoginBtn not found.");
                }
                Console.WriteLine("Login test Sucsess");
            }
            catch (ElementNotVisibleException e)
            {
                Console.WriteLine("Test failded", e.Message);
            }
        }
        public Login(IWebDriver webDriver)
        {
            WebDriver = webDriver;
        }
    }
}
