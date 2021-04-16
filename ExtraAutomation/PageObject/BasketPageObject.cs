using NUnit.Framework;
using OpenQA.Selenium;
using QAssistant.Extensions;
using SeleniumHelper.Base;

namespace ExtraAutomation.PageObject
{
    public class BasketPageObject : BaseClass
    {
        public const string BasketProductQuantity = "/html/body/app-root/app-header/div[1]/div/div/div[3]/div[1]/div[2]/button/span";
        public const string OrderProdyctQuantity = "/html/body/app-root/div[1]/app-basket-page/div/div/div/div[2]/div/div/ul/li[1]/var";
        private static readonly By FindCountProduct = By.XPath("//div[@class='mr-md-30px flex-grow-1']//div//div//div[@class='d-flex justify-content-md-between justify-content-end align-items-end']//a[1]");


        private const string DeleteBasket = "//div[@class='d-flex justify-content-md-between justify-content-end align-items-end']/child::a";
        private const string AddProductHomePage = "//div[contains(@class,'slider-container')][1]//app-product-item[2]//button[contains(text(),' კალათაში დამატება ')]";
        private const string BasketButton = "//span[text()='კალათა']";
        private const string BasketInButton = "//app-basket//button[contains(text(),'კალათა')]";

        private const string AddProductQuantity = "//i[@class='plus icon-disabled cursor-pointer px-5px']";
        private const string ReduceProductQuantity = "//i[@class='minus icon-disabled cursor-pointer px-5px']";

        protected static void AddProductInBasket()
        {
            IJavaScriptExecutor js = WebDriver as IJavaScriptExecutor;
            if (js != null)
            {
                js.ExecuteScript("window.scrollBy(0,1050);");
                BaseMethods.WaitSomeInterval(3);
                WebDriver.WaitUntilFindElement(By.XPath(AddProductHomePage)).Click();
                js.ExecuteScript("window.scrollBy(0,-1050);");
            }
        }

        protected static void DeleteProducts()
        {
            int element = WebDriver.FindElements(FindCountProduct).Count;
            for (int i = 0; i < element; i++)
            {
                WebDriver.Click(By.XPath(DeleteBasket));
                BaseMethods.WaitSomeInterval(1);
            }
        }

        protected static void AddProductQuantityMethod()
        {
            WebDriver.WaitUntilFindElement(By.XPath(AddProductQuantity)).Click();
            Assert.IsTrue(CheckMethods.CheckCount(BasketProductQuantity, OrderProdyctQuantity, WebDriver));
        }

        protected static void ReduceProductQuantityMethod()
        {
            WebDriver.WaitUntilFindElement(By.XPath(ReduceProductQuantity)).Click();
            Assert.IsTrue(CheckMethods.CheckCount(BasketProductQuantity, OrderProdyctQuantity, WebDriver));
        }

        protected static void GetBasket()
        {
            WebDriver.Click(By.XPath(BasketButton));
            WebDriver.WaitUntilFindElement(By.XPath(BasketInButton)).Click();

        }

    }
}
