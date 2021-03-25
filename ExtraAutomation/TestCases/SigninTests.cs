using ExtraAutomation.PageObject;
using NUnit.Framework;
using OpenQA.Selenium;
using QAssistant.Extensions;
using QAssistant.WaitHelpers;
using SeleniumHelper.ComponentHelper;


namespace ExtraAutomation.TestCases
{


    //[Parallelizable(ParallelScope.Children)]
    [TestFixture]
    public class SigninTests : AuthorizationPageObject
    {

        [Test, Category("Sucssesful Login Test")]
        public static void SucssesfulLoginTest()
        {
            Assert.AreEqual(WebDriver.Title, "🌈 Extra.ge - რაც გაგიხარდება");
            HomePageObject.SignIn();
            EnterUserName(enterUserName);
            EnterPassword(enterPassword);
            WebDriver.Click(By.XPath(LogginButton));
            Assert.IsTrue(CheckMethods.CheckValidLogin(WebDriver, checkedlocator));
        }

        [Test, Category("Wrong Username Login Test")]
        public static void WrongUserNameLoginTest()
        {
            Assert.AreEqual(WebDriver.Title, "🌈 Extra.ge - რაც გაგიხარდება");
            HomePageObject.SignIn();
            EnterUserName("Wrong Username");
            EnterPassword(enterPassword);
            Assert.IsNotNull(ExpectedConditions.ElementToBeClickable(By.XPath(LogginButton)));

        }

        [Test, Category("Wrong Password Login Test")]
        public static void WrongPasswordLoginTest()
        {
            Assert.AreEqual(WebDriver.Title, "🌈 Extra.ge - რაც გაგიხარდება");
            HomePageObject.SignIn();
            EnterUserName(enterUserName);
            EnterPassword("wrongPassword");
            WebDriver.Click(By.XPath(LogginButton));
            WebDriver.WaitUntilFindElement(By.XPath(ValidLoginEnterWrongPass));

        }
    }
}
