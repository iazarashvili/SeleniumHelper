using ExtraAutomationTesting;
using NUnit.Framework;
using OpenQA.Selenium;
using QAssistant.Extensions;
using SeleniumHelper.Base;
using SeleniumHelper.ComponentHelper;

namespace ExtraAutomation.PageObject
{
    class BasketPageObject : BaseClass
    {
        private string first = "//span[@class='_s_position-absolute _s_position-minus-r-px--1 _s_position-t-px--0 _s_label _s_label-sm _s_color-orange _s_label-bold']";
        private string last = "//var[@class='text-normal font-medium font-size-14 text-gray'][1]";
        private By findCountProduct = By.XPath("//div[@class='mr-md-30px flex-grow-1']//div//div//div[@class='d-flex justify-content-md-between justify-content-end align-items-end']//a[1]");


        private string DeleteBasket = "//div[@class='d-flex justify-content-md-between justify-content-end align-items-end']/child::a";
        private string addProductHomePage = "//div[contains(@class,'slider-container')][1]//app-product-item[2]//button[contains(text(),' კალათაში დამატება ')]";
        private string basketButton = "//span[text()='კალათა']";
        private string basketInButton = "//app-basket//button[contains(text(),'კალათა')]";

        private string addProduct = "//i[@class='plus icon-disabled cursor-pointer px-5px']";
        private string deductProduct = "//i[@class='minus icon-disabled cursor-pointer px-5px']";


        public BasketPageObject checkBaskets()
        {
            IJavaScriptExecutor js = WebDriver as IJavaScriptExecutor;
            js.ExecuteScript("window.scrollBy(0,1050);");
            BaseMethods.WaitSomeInterval(3);
            WebDriver.WaitUntilFindElement(By.XPath(addProductHomePage)).Click();
            js.ExecuteScript("window.scrollBy(0,-1050);");

            WebDriver.Click(By.XPath(basketButton));

            WebDriver.WaitUntilFindElement(By.XPath(basketInButton)).Click();
            Assert.IsTrue(CheckMethods.CheckCount(first, last, WebDriver));

            WebDriver.WaitUntilFindElement(By.XPath(addProduct)).Click();
            Assert.IsTrue(CheckMethods.CheckCount(first, last, WebDriver));

            WebDriver.WaitUntilFindElement(By.XPath(deductProduct)).Click();
            Assert.IsTrue(CheckMethods.CheckCount(first, last, WebDriver));
            BaseMethods.WaitSomeInterval(1);

            int element = WebDriver.FindElements(findCountProduct).Count;
            for (int i = 0; i < element; i++)
            {
                WebDriver.Click(By.XPath(DeleteBasket));
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
