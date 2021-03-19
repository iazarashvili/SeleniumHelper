using ExtraAutomation.PageObject;
using ExtraAutomationTesting;
using NUnit.Framework;

namespace ExtraAutomation.TestCases
{
    [TestFixture]
    public class Login : BaseClass
    {

        [Test]
        public void TestLogin()
        {
            var authorization = new HomePageObject(WebDriver)
                  .SignIn()
                  .Login();
        }
    }
}
