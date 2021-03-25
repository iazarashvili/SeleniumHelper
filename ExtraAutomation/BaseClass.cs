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
        public static IWebDriver WebDriver;
        public static IWebElement Element;

        [SetUp]
        public static void DoBeforeAllTheTest()
        {
            var chromeOption = new ChromeOptions();
            chromeOption.PageLoadStrategy = PageLoadStrategy.Normal;
            chromeOption.AddArguments("--disable-popup-blocking");
            chromeOption.AddArguments("test-type");
            WebDriver = new ChromeDriver(@"E:\Extra\NewProjectAuto\SeleniumHelper\Driver", chromeOption, TimeSpan.FromMinutes(2));
            WebDriver.Manage().Window.Maximize();
            WebDriver.Navigate().GoToUrl("https://extra.ge/");
            BaseMethods.ShouldLocate(WebDriver, "https://extra.ge/");

        }


        [TearDown]
        public static void DoAfterEach()
        {

            WebDriver.Close();
            WebDriver.Dispose();

        }

    }
}
