using ExtraAutomationTesting;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumHelper.Base;
using SeleniumHelper.ComponentHelper;
using SingularQATestService;
using System.Threading;

namespace ExtraAutomation.TestCases
{
    [TestFixture]
    class Basket : BaseClass
    {
        public static By first = By.XPath("//span[contains(@class,'position-absolute absolute--right-top-position absolute--transform-50 text-orange ')]");
        public static By last = By.XPath("//var[@class='text-normal font-medium font-size-14 text-gray'][1]");
       
        public static By DeleteBasket = By.XPath("//app-basket-page//div[@class='container']/div/div/div/div/div[2]/div/a");
        public static string addProductHomePage = "//div[contains(@class,'slider-container')][1]//app-product-item[2]//button[contains(text(),'დამატება')]";
        public static string basketButton = "//span[text()='კალათა']";
        public static string basketInButton = "//div[contains(@class,'justify-content-between mb-60px')]//button[1]";

        public static string addProduct = "//i[@class='plus icon-disabled cursor-pointer px-5px']";
        public static string deductProduct = "//i[@class='minus icon-disabled cursor-pointer px-5px']";

        [Test, Category("Basket Test")]
        public  void BasketCheckTest()
        {
            var login = new Login(WebDriver);
            login.TestLogin();
            IJavaScriptExecutor js = WebDriver as IJavaScriptExecutor;
            js.ExecuteScript("window.scrollBy(0,950);");

            BaseMethods.WaitTillElementDisplayed(WebDriver, addProductHomePage, ElementLocator.Xpath);
            BaseMethods.Click(WebDriver, ElementLocator.Xpath, addProductHomePage);
            js.ExecuteScript("window.scrollBy(0,-950);");

            IWebElement basket = BaseMethods.WaitTillElementDisplayed(WebDriver, basketButton, ElementLocator.Xpath);
            basket.Click();
            BaseMethods.Click(WebDriver, ElementLocator.Xpath, basketInButton);
            Assert.IsTrue(CheckMethods.CheckCount(first, last, WebDriver));
            BaseMethods.Click(WebDriver, ElementLocator.Xpath, addProduct);
            Assert.IsTrue(CheckMethods.CheckCount(first, last, WebDriver));
            BaseMethods.Click(WebDriver, ElementLocator.Xpath, deductProduct);

            int element = WebDriver.FindElements(DeleteBasket).Count;
            for (int i = 0; i < element; i++)
            {
                WebDriver.FindElement(DeleteBasket).Click();
                Thread.Sleep(500);
            }
        }
    }
}
