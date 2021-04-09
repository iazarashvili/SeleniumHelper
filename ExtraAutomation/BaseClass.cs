using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumHelper.Base;
using System;

namespace ExtraAutomationTesting
{
    //driver.Wait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("selectori aq "))).Click();
    [TestFixture]
    public class BaseClass
    {
        protected static IWebDriver WebDriver;
        protected static IWebElement Element;
        protected static ChromeOptions _chromeoptions;
        [OneTimeSetUp]
        protected static void DoBeforeAllTheTest()
        {
            _chromeoptions = new ChromeOptions();
            WebDriver = new ChromeDriver(@"E:\Extra\NewProjectAuto\SeleniumHelper\Driver", _chromeoptions, TimeSpan.FromMinutes(2));

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
        protected static void DobeforeEach()
        {
            WebDriver.Manage().Cookies.DeleteAllCookies();
            _chromeoptions.PageLoadStrategy = PageLoadStrategy.Normal;
            _chromeoptions.AddArguments("--disable-popup-blocking");
            _chromeoptions.AddArguments("test-type");
            WebDriver.Manage().Window.Maximize();
            WebDriver.Navigate().GoToUrl("https://extra.ge/");
            BaseMethods.ShouldLocate(WebDriver, "https://extra.ge/");
        }
    }
}
