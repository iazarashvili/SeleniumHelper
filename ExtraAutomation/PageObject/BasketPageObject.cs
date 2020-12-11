using ExtraAutomationTesting;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumHelper.Base;
using SeleniumHelper.ComponentHelper;

namespace ExtraAutomation.PageObject
{
    class BasketPageObject : BaseClass
    {
        public string first = "//span[contains(@class,'position-absolute absolute--right-top-position absolute--transform-50 text-orange ')]";
        public string last = "//var[@class='text-normal font-medium font-size-14 text-gray'][1]";
        public By findCountProduct = By.XPath("//div[@class='mr-md-30px flex-grow-1']//div//div//div[@class='d-flex justify-content-md-between justify-content-end align-items-end']//a[1]");


        public string DeleteBasket = "//div[@class='d-flex justify-content-md-between justify-content-end align-items-end']/child::a";
        public string addProductHomePage = "//div[contains(@class,'slider-container')][1]//app-product-item[2]//button[contains(text(),' კალათაში დამატება ')]";
        public string basketButton = "//span[text()='კალათა']";
        public string basketInButton = "//app-basket//button[contains(text(),'კალათა')]";

        public string addProduct = "//i[@class='plus icon-disabled cursor-pointer px-5px']";
        public string deductProduct = "//i[@class='minus icon-disabled cursor-pointer px-5px']";


        public BasketPageObject checkBaskets()
        {
            IJavaScriptExecutor js = WebDriver as IJavaScriptExecutor;
            js.ExecuteScript("window.scrollBy(0,950);");

            BaseMethods.WaitSomeInterval(3);
            BaseMethods.ClickElement(WebDriver, ElementLocator.Xpath, addProductHomePage);
            js.ExecuteScript("window.scrollBy(0,-950);");

           
            BaseMethods.ClickElement(WebDriver, ElementLocator.Xpath, basketButton);

            BaseMethods.WaitDispleed(WebDriver, ElementLocator.Xpath, basketInButton);
            BaseMethods.ClickElement(WebDriver, ElementLocator.Xpath, basketInButton);
            Assert.IsTrue(CheckMethods.CheckCount(first, last, WebDriver));
            BaseMethods.WaitDispleed(WebDriver, ElementLocator.Xpath, addProduct);
            BaseMethods.ClickElement(WebDriver, ElementLocator.Xpath, addProduct);
            Assert.IsTrue(CheckMethods.CheckCount(first, last, WebDriver));
            BaseMethods.WaitDispleed(WebDriver, ElementLocator.Xpath, deductProduct);
            BaseMethods.ClickElement(WebDriver, ElementLocator.Xpath, deductProduct);
            Assert.IsTrue(CheckMethods.CheckCount(first, last, WebDriver));
            BaseMethods.WaitSomeInterval(1);

            int element = WebDriver.FindElements(findCountProduct).Count;
            for (int i = 0; i < element; i++)
            {
                BaseMethods.ClickElement(WebDriver, ElementLocator.Xpath, DeleteBasket);
                BaseMethods.WaitSomeInterval(1);
            }
            return new BasketPageObject(WebDriver);
        }

        public BasketPageObject(IWebDriver webDriver)
        {
            WebDriver = webDriver;
        }
    }
}
