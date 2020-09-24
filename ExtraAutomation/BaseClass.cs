using ExtraAutomation.TestCases;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools.Network;
using System;
using System.Threading;

namespace ExtraAutomationTesting
{
    public class BaseClass
    {
        protected IWebDriver WebDriver;

        [OneTimeSetUp]
        protected void DoBeforeAllTheTest()
        {
            var chromeOption = new ChromeOptions();
            chromeOption.PageLoadStrategy = PageLoadStrategy.Normal;
            WebDriver = new ChromeDriver(@"G:\Extra\New Project Auto\SeleniumHelper\SeleniumHelper\Driver", chromeOption, TimeSpan.FromMinutes(2));
           
        }


        [OneTimeTearDown]
        protected void DoAfterAllTheTests()
        {

        }

        [TearDown]
        protected void DoAfterEach()
        {
            //WebDriver.Close();
        }
        [SetUp]

        protected void DobeforeEach()
        {
            WebDriver.Navigate().GoToUrl(Login.HostUrl);
            WebDriver.Manage().Window.Maximize();
            
        }

    }
}
