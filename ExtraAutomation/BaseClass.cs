
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
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
        protected static ChromeOptions Chromeoptions;
        protected static ExtentReports Extent;
        protected static ExtentTest Test;


        [OneTimeSetUp]
        protected static void DoBeforeAllTheTest()
        {
            Chromeoptions = new ChromeOptions();
            WebDriver = new ChromeDriver(@"E:\Extra\NewProjectAuto\SeleniumHelper\Driver", Chromeoptions, TimeSpan.FromMinutes(12));

            // reports

            var path = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            if (path != null)
            {
                var actualPath = path.Substring(0, path.LastIndexOf("bin", StringComparison.Ordinal));
                var projectPath = new Uri(actualPath).LocalPath;
                Directory.CreateDirectory(projectPath + "Reports");
                var reportPath = projectPath + @"Reports\ExtentReport.html";
                var htmlReporter = new ExtentHtmlReporter(reportPath);
                Extent = new ExtentReports();
                Extent.AttachReporter(htmlReporter);
                //var sparkAll = new ExtentKlovReporter("Klov.html");
                //Extent.AttachReporter(htmlReporter, sparkAll);
            }


            Extent.AddSystemInfo("Host Name", "LocalHost");
            Extent.AddSystemInfo("Environment", "QA");
            Extent.AddSystemInfo("UserName", "TestUser");
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
                    Test.Log(Status.Fail, "Fail");
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
            Test.Log(logstatus, "Test ended with " + logstatus + stacktrace);
            Extent.Flush();
            WebDriver.Quit();
        }
        // ყველა ტესტის წინ

        [SetUp]
        protected static void DobeforeEach()
        {
            Chromeoptions.PageLoadStrategy = PageLoadStrategy.Normal;
            Chromeoptions.AddArguments("--disable-popup-blocking");
            Chromeoptions.AddArguments("test-type");
            WebDriver.Manage().Window.Maximize();
            WebDriver.Navigate().GoToUrl("https://extra.ge/");
            BaseMethods.ShouldLocate(WebDriver, "https://extra.ge/");
            Test = Extent.CreateTest(TestContext.CurrentContext.Test.Name);
        }
    }
}
