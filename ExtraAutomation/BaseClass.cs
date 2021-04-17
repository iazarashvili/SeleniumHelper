
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumHelper.Base;
using System;
using System.IO;

namespace ExtraAutomation
{
    //driver.Wait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("selectori aq "))).Click();

    public class BaseClass
    {
        protected static IWebDriver WebDriver;
        private static ChromeOptions _chromeOptions;
        private static ExtentReports _extent;
        private static readonly ExtentTest _test;


        [OneTimeSetUp]
        protected static void DoBeforeAllTheTest()
        {
            _chromeOptions = new ChromeOptions();
            _chromeOptions.AddArgument("start-maximized");
            WebDriver = new ChromeDriver(@"D:\Projects\SeleniumHelper\SeleniumHelper\Driver", _chromeOptions);
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
            WebDriver.Quit();
        }
        // ყველა ტესტის წინ

        [SetUp]
        protected static void DoBeforeEach()
        {
            
            WebDriver.Navigate().GoToUrl("https://extra.ge/");
            
            BaseMethods.ShouldLocate(WebDriver, "https://extra.ge/");
        }
    }
}
