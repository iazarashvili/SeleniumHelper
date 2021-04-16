
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
            _extent = new ExtentReports();


            //var actualPath = path.Substring(0, path.LastIndexOf("bin", StringComparison.Ordinal));
            //var projectPath = new Uri(actualPath).LocalPath;
            //Directory.CreateDirectory(projectPath + "Reports");
            string reportPaths = @"C:\Users\Administrator\Desktop\QALoger\ExtentReport.html";

            try
            {
                if (Directory.Exists(reportPaths))
                {
                    Console.WriteLine("That path exists already.");
                    return;
                }
                DirectoryInfo di = Directory.CreateDirectory(reportPaths);
                Console.WriteLine("The directory was created successfully at {0}.", Directory.GetCreationTime(reportPaths));

                // Delete the directory.
                di.Delete();
                Console.WriteLine("The directory was deleted successfully.");
            }
            catch (Exception e)
            {
                Console.WriteLine("The process failed: {0}", e.ToString());
                throw;
            }
            //var reportPath = reportPaths + "ExtentReport.html";
            var htmlReporter = new ExtentHtmlReporter(reportPaths, ViewStyle.Default);
            _extent.AttachReporter(htmlReporter);



            _extent.AddSystemInfo("Host Name", "LocalHost");
            _extent.AddSystemInfo("Environment", "QA");
            _extent.AddSystemInfo("UserName", "TestUser");
        }

        // სრულდება ერთხელ ყველა ტესტის შემდეგ

        [OneTimeTearDown]
        protected static void DoAfterAllTheTests()
        {
            _extent.Flush();
        }

        //სრულდება ერთხელ ყველა ტესტის შემდეგ

        [TearDown]
        protected static void DoAfterEach()
        {
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var stacktrace = string.IsNullOrEmpty(TestContext.CurrentContext.Result.StackTrace) ? ""
                : string.Format("{0}", TestContext.CurrentContext.Result.StackTrace);
            Status logstatus = Status.Pass;
            switch (status)
            {
                case TestStatus.Failed:
                    logstatus = Status.Fail;
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

            WebDriver.Quit();
        }
        // ყველა ტესტის წინ

        [SetUp]
        protected static void DoBeforeEach()
        {
            _extent.CreateTest(TestContext.CurrentContext.Test.Name);
            WebDriver = new ChromeDriver(@"D:\GitProj\SeleniumHelper\SeleniumHelper\Driver", _chromeOptions, TimeSpan.FromMinutes(12));
            WebDriver.Navigate().GoToUrl("https://extra.ge/");
            WebDriver.Manage().Window.Maximize();
            _chromeOptions.PageLoadStrategy = PageLoadStrategy.Normal;
            BaseMethods.ShouldLocate(WebDriver, "https://extra.ge/");
        }
    }
}
