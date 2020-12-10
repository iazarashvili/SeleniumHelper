using ExtraAutomation.PageObject;
using ExtraAutomationTesting;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumHelper.Base;
using SeleniumHelper.ComponentHelper;
using System;

namespace ExtraAutomation.TestCases
{
    [TestFixture]
    public class Login : BaseClass
    {
        [Test, Category("Login test")]
        public void TestLogin()
        {
            var authorization = new HomePageObject(WebDriver)
                  .SignIn()
                  .Login();
        }
    }
}
