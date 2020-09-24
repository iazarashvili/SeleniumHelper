using ExtraAutomationTesting;
using SingularQATestService;
using SeleniumHelper.Base;
using NUnit.Framework;

namespace ExtraAutomation.TestCases
{
    [TestFixture]
    class PaymentMethodBalance : BaseClass
    {
        public static string SearchInput = "//div[@id='header']//div//div//div//div//input";
        public static string SearchButton ="//div[@class='rounded-lg search-wrap w-100 h-60px w-100" +
            " bg-gray-550 d-flex align-items-center']//child::button";
        public static string AddProduct = "//button[text()=' კალათაში დამატება ']";
        public static string Basket = "//span[text()='კალათა']";
        public static string ShopButton = "//button[text()=' ყიდვა ']";

        public static string PaymentByCardButton = "//span[text()='ბარათით გადახდა']";
        public static string OrderCompleteButton = "//button[text()=' შეკვეთის დასრულება ']";

        [Test, Category("Paymant Method Balance")]
        public void PaymantTestBalance()
        {
            var login = new Login(WebDriver);
            login.TestLogin();
            BaseMethods.SendKeys(WebDriver, ElementLocator.Xpath, SearchInput, "80509");
        }
    }
}
