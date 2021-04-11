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
                EnterUserName(enterUserName);
                EnterPassword(enterPassword);
                WebDriver.Click(By.XPath(logginButton));
                Assert.IsTrue(CheckMethods.CheckValidLogin(WebDriver, checkedlocator));
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
                EnterUserName("Wrong Username");
                EnterPassword(enterPassword);
                WebDriver.WaitUntilElementIsDisplayed(By.XPath(validLoginEnterWrongPass));
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
                EnterUserName(enterUserName);
                EnterPassword("wrongPassword");
                WebDriver.WaitUntilFindElement(By.XPath(validLoginEnterWrongPass));
            }
            catch (AuthenticationException ex)
            {
                Console.WriteLine("Wrong Password Login Test was not performed" + ex.Message);
            }
            Console.WriteLine("Wrong Password Login  test was performed successfully");
        }
    }
}
