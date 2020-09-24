using ExtraAutomationTesting;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumHelper.Base;
using SingularQATestService;

namespace ExtraAutomation.TestCases
{
    [TestFixture]
    class Basket : BaseClass
    {
        public static string first = "//span[contains(@class,'position-absolute absolute--right-top-position absolute--transform-50 text-orange ')]";
        public static string last = "//var[@class='text-normal font-medium font-size-14 text-gray'][1]";
        public static string addProduct = "//i[@class='plus icon-disabled cursor-pointer px-5px']";
        public static string deductProduct = "//i[@class='minus icon-disabled cursor-pointer px-5px']";
        public static string DeleteBasket = "//app-basket-page//div[@class='container']/div/div/div/div/div[2]/div/a";
        public static string addProductHomePage = "//div[contains(@class,'slider-container')][1]//app-product-item[2]//button[contains(text(),'დამატება')]";
        public static string Bas = "//span[text()='კალათა']";
        public static string BasketIn = "//div[contains(@class,'justify-content-between mb-60px')]//button[1]";

        [Test, Category("Basket Test")]
        public  void BasketCheckTest()
        {
            var login = new Login();
            login.TestLogin();
            IJavaScriptExecutor js = WebDriver as IJavaScriptExecutor;
            js.ExecuteScript("window.scrollBy(0,950);");

            BaseMethods.WaitToBeClickable(WebDriver, ElementLocator.Xpath, addProductHomePage);
            BaseMethods.Click(WebDriver, ElementLocator.Xpath, addProductHomePage);

        }

    }
}
