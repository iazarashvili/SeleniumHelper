using ExtraAutomation.PageObject;
using ExtraAutomationTesting;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumHelper.Base;
using SeleniumHelper.ComponentHelper;
using System.Threading;

namespace ExtraAutomation.TestCases
{
    [TestFixture]
    class Basket : BaseClass
    {
        [Test, Category("Basket Test")]

        public void BasketCheck()
        {
            var signIn = new HomePageObject(WebDriver)
                .SignIn()
                .Login();

            var basketCheck = new BasketPageObject(WebDriver);
            basketCheck.checkBaskets();
             

        }
    }
}
