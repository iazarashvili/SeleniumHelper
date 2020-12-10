using ExtraAutomation.PageObject;
using ExtraAutomationTesting;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumHelper.Base;
using SeleniumHelper.ComponentHelper;
using System.Threading;

namespace ExtraAutomation.TestCases
{
    [TestFixture]
    class Basket : BaseClass
    {
        public static string first = "//span[contains(@class,'position-absolute absolute--right-top-position absolute--transform-50 text-orange ')]";
        public static string last = "//var[@class='text-normal font-medium font-size-14 text-gray'][1]";
        public static By findCountProduct = By.XPath("//div[@class='mr-md-30px flex-grow-1']//div//div//div[@class='d-flex justify-content-md-between justify-content-end align-items-end']//a[1]");

       
        public static string DeleteBasket = "//div[@class='d-flex justify-content-md-between justify-content-end align-items-end']/child::a";
        public static string addProductHomePage = "//div[contains(@class,'slider-container')][1]//app-product-item[2]//button[contains(text(),'დამატება')]";
        public static string basketButton = "//span[text()='კალათა']";
        public static string basketInButton = "//app-basket//button[contains(text(),'კალათა')]";

        public static string addProduct = "//i[@class='plus icon-disabled cursor-pointer px-5px']";
        public static string deductProduct = "//i[@class='minus icon-disabled cursor-pointer px-5px']";

      

        [Test, Category("Basket Test")]
        public  void BasketCheckTest()
        {
            var login = new HomePageObject(WebDriver)
                .SignIn()
                .Login();
            IJavaScriptExecutor js = WebDriver as IJavaScriptExecutor;
            js.ExecuteScript("window.scrollBy(0,950);");

            BaseMethods.WaitTillElementDisplayed(WebDriver, addProductHomePage, ElementLocator.Xpath);
            BaseMethods.Click(WebDriver, ElementLocator.Xpath, addProductHomePage);
            js.ExecuteScript("window.scrollBy(0,-950);");

            BaseMethods.WaitTillElementDisplayed(WebDriver, basketButton, ElementLocator.Xpath);
            BaseMethods.Click(WebDriver, ElementLocator.Xpath, basketButton);
           
            BaseMethods.Wait(WebDriver, ElementLocator.Xpath, basketInButton);
            BaseMethods.Click(WebDriver, ElementLocator.Xpath, basketInButton);
            Assert.IsTrue(CheckMethods.CheckCount(first, last, WebDriver));
            BaseMethods.Wait(WebDriver, ElementLocator.Xpath, addProduct);
            BaseMethods.Click(WebDriver, ElementLocator.Xpath, addProduct);
            Assert.IsTrue(CheckMethods.CheckCount(first, last, WebDriver));
            BaseMethods.Wait(WebDriver, ElementLocator.Xpath, deductProduct);
            BaseMethods.Click(WebDriver, ElementLocator.Xpath, deductProduct);
            Assert.IsTrue(CheckMethods.CheckCount(first, last, WebDriver));
            Thread.Sleep(2000);

            int element = WebDriver.FindElements(findCountProduct).Count;
            for (int i = 0; i < element; i++)
            {
                BaseMethods.Click(WebDriver, ElementLocator.Xpath, DeleteBasket);
                Thread.Sleep(500);
            }
        }
    }
}
