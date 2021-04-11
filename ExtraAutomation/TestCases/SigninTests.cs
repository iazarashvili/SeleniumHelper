using ExtraAutomation.PageObject;
using NUnit.Framework;
using OpenQA.Selenium;
using QAssistant.Extensions;
using SeleniumHelper.Base;
using System;
using System.Security.Authentication;

namespace ExtraAutomation.TestCases
{



    [TestFixture]
    public class SigninTests : AuthorizationPageObject
    {

        [Test]
        [Category("Sucssesful Login Test")]
        public static void SucssesfulLoginTest()
        {
            try
            {
                Assert.AreEqual(WebDriver.Title, "🌈 Extra.ge - რაც გაგიხარდება");
                HomePageObject.SignIn();
                EnterUserNameMethod(EnterUserName);
                EnterPasswordMethod(EnterPassword);
                WebDriver.Click(By.XPath(LoginButton));
                Assert.IsTrue(CheckMethods.CheckValidLogin(WebDriver, CheckedLocator));
            }
            catch (AuthenticationException ex)
            {
                Console.WriteLine("Sucssesful Login test was not performed" + ex.Message);
            }

            Console.WriteLine("Login test was performed successfully");
        }

        [Test]
        [Category("Wrong Username Login Test")]
        public static void WrongUserNameLoginTest()
        {
            try
            {
                Assert.AreEqual(WebDriver.Title, "🌈 Extra.ge - რაც გაგიხარდება");
                HomePageObject.SignIn();
                EnterUserNameMethod("Wrong Username");
                EnterPasswordMethod(EnterPassword);
                WebDriver.WaitUntilElementIsDisplayed(By.XPath(ValidLoginEnterWrongPass));
            }
            catch (AuthenticationException ex)
            {
                Console.WriteLine("WrongUserNameLoginTest The test was not performed" + ex.Message);
            }

            Console.WriteLine("WrongUserNameLoginTest The test was performed successfully");
        }

        [Test]
        [Category("Wrong Password Login Test")]
        public static void WrongPasswordLoginTest()
        {
            try
            {
                Assert.AreEqual(WebDriver.Title, "🌈 Extra.ge - რაც გაგიხარდება");
                HomePageObject.SignIn();
                EnterUserNameMethod(EnterUserName);
                EnterPasswordMethod("wrongPassword");
                WebDriver.WaitUntilFindElement(By.XPath(ValidLoginEnterWrongPass));
            }
            catch (AuthenticationException ex)
            {
                Console.WriteLine("Wrong Password Login Test was not performed" + ex.Message);
            }
            Console.WriteLine("Wrong Password Login  test was performed successfully");
        }
    }
}
