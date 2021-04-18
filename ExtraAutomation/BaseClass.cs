
using AventStack.ExtentReports;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumHelper.Base;
using System;


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
            _chromeOptions.AddArgument("start-maximized");

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

<<<<<<< Updated upstream

=======
            try
            {
                var status = TestContext.CurrentContext.Result.Outcome.Status;
                var stacktrace = " +TestContext.CurrentContext.Result.StackTrace + ";
                var errorMessage = TestContext.CurrentContext.Result.Message;
                Status logstatus;
                switch (status)
                {
                    case TestStatus.Failed:
                        logstatus = Status.Fail;
                        _test.Log(logstatus, "Test ended with " + logstatus + " – " + errorMessage);
                        break;
                    case TestStatus.Skipped:
                        logstatus = Status.Skip;
                        _test.Log(logstatus, "Test ended with " + logstatus);
                        break;
                    default:
                        logstatus = Status.Pass;
                        _test.Log(logstatus, "Test ended with " + logstatus);
                        break;
                }
            }
            catch (Exception e)
            {
                throw (e);
            }
>>>>>>> Stashed changes
            WebDriver.Quit();
        }
        // ყველა ტესტის წინ

        [SetUp]
        protected static void DoBeforeEach()
        {

            WebDriver = new ChromeDriver(@"D:\GitProj\SeleniumHelper\SeleniumHelper\Driver", _chromeOptions, TimeSpan.FromMinutes(12));
            WebDriver.Navigate().GoToUrl("https://extra.ge/");
            WebDriver.Manage().Window.Maximize();
            _chromeOptions.PageLoadStrategy = PageLoadStrategy.Normal;
            BaseMethods.ShouldLocate(WebDriver, "https://extra.ge/");
        }
    }
}
