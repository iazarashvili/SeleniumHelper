using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumHelper.Base;
using System;

namespace ExtraAutomationTesting
{
    public class BaseClass
    {
        protected IWebDriver WebDriver;
        // D:\Projects\ExtraAuto\SeleniumHelper\SeleniumHelper\Driver
        //G:\Extra\New Project Auto\SeleniumHelper\SeleniumHelper\Driver"
        [OneTimeSetUp]
        protected void DoBeforeAllTheTest()
        {
            var chromeOption = new ChromeOptions();
            chromeOption.PageLoadStrategy = PageLoadStrategy.Normal;
            chromeOption.AddArguments("--disable-popup-blocking");
            chromeOption.AddArguments("test-type");
            WebDriver = new ChromeDriver(@"E:\Extra\NewProjectAuto\SeleniumHelper\SeleniumHelper\Driver", chromeOption, TimeSpan.FromMinutes(2));
            WebDriver.Manage().Window.Maximize();

        }


        [OneTimeTearDown]
        protected void DoAfterAllTheTests()
        {

        }

        [TearDown]
        protected void DoAfterEach()
        {
            WebDriver.Close();
            WebDriver.Quit();
        }
        [SetUp]

        protected void DobeforeEach()
        {
            WebDriver.Navigate().GoToUrl("https://extra.ge/");
            BaseMethods.ShouldLocate(WebDriver, "https://extra.ge/");

        }

    }
}
