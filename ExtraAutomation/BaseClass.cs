using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumHelper.Base;
using System;

namespace ExtraAutomation
{
    //driver.Wait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("selectori aq "))).Click();
    [TestFixture]
    public class BaseClass
    {
        protected static IWebDriver WebDriver;
        private static ChromeOptions _chromeOptions;

        [OneTimeSetUp]
        protected static void DoBeforeAllTheTest()
        {
            _chromeOptions = new ChromeOptions();


        }

        // სრულდება ერთხელ ყველა ტესტის შემდეგ
        [OneTimeTearDown]
        protected static void DoAfterAllTheTests()
        {

        }

        //სრულდება ერთხელ ყველა ტესტის შემდეგ
        [TearDown]
        protected static void DoAfterEach()
        {

            WebDriver.Close();
            WebDriver.Dispose();

        }

        // ყველა ტესტის წინ
        [SetUp]
        protected static void DoBeforeEach()
        {
            WebDriver = new ChromeDriver(@"E:\Extra\NewProjectAuto\SeleniumHelper\Driver", _chromeOptions, TimeSpan.FromMinutes(12));
            WebDriver.Navigate().GoToUrl("https://extra.ge/");
            WebDriver.Manage().Window.Maximize();
            _chromeOptions.PageLoadStrategy = PageLoadStrategy.Normal;
            BaseMethods.ShouldLocate(WebDriver, "https://extra.ge/");
        }
    }
}
