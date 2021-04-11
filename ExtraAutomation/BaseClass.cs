
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
        private static ExtentTest _test;



        [OneTimeSetUp]
        protected static void DoBeforeAllTheTest()
        {

            _chromeOptions = new ChromeOptions();



            var path = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            if (path != null)
            {
                var actualPath = path.Substring(0, path.LastIndexOf("bin", StringComparison.Ordinal));
                var projectPath = new Uri(actualPath).LocalPath;
                Directory.CreateDirectory(projectPath + "Reports");
                var reportPath = projectPath + @"Reports\ExtentReport.html";
                var htmlReporter = new ExtentHtmlReporter(reportPath, ViewStyle.Default);
                _extent = new ExtentReports();
                _extent.AttachReporter(htmlReporter);

            }

            _extent.AddSystemInfo("Host Name", "LocalHost");
            _extent.AddSystemInfo("Environment", "QA");
            _extent.AddSystemInfo("UserName", "TestUser");
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
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var stacktrace = string.IsNullOrEmpty(TestContext.CurrentContext.Result.StackTrace) ? ""
                : string.Format("{0}", TestContext.CurrentContext.Result.StackTrace);
            Status logstatus;
            switch (status)
            {
                case TestStatus.Failed:
                    logstatus = Status.Fail;
                    _test.Log(Status.Fail, "Fail");
                    break;
                case TestStatus.Inconclusive:
                    logstatus = Status.Warning;
                    break;
                case TestStatus.Skipped:
                    logstatus = Status.Skip;
                    break;
                default:
                    logstatus = Status.Pass;
                    break;
            }
            _test.Log(logstatus, "Test ended with " + logstatus + stacktrace);
            _extent.Flush();
            WebDriver.Quit();
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
            _test = _extent.CreateTest(TestContext.CurrentContext.Test.Name);
        }
    }
}
