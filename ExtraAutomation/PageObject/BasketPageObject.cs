using NUnit.Framework;
using OpenQA.Selenium;
using QAssistant.Extensions;
using SeleniumHelper.Base;

namespace ExtraAutomation.PageObject
{
    public class BasketPageObject : BaseClass
    {
        public static readonly string basketProductQuantity = "//span[@class='_s_position-absolute _s_position-minus-r-px--1 _s_position-t-px--0 _s_label _s_label-sm _s_color-orange _s_label-bold']";
        public static readonly string orderProdyctQuantity = "//var[@class='text-normal font-medium font-size-14 text-gray'][1]";
        public static readonly By findCountProduct = By.XPath("//div[@class='mr-md-30px flex-grow-1']//div//div//div[@class='d-flex justify-content-md-between justify-content-end align-items-end']//a[1]");


        public static readonly string deleteBasket = "//div[@class='d-flex justify-content-md-between justify-content-end align-items-end']/child::a";
        public static readonly string addProductHomePage = "//div[contains(@class,'slider-container')][1]//app-product-item[2]//button[contains(text(),' კალათაში დამატება ')]";
        public static readonly string basketButton = "//span[text()='კალათა']";
        public static readonly string basketInButton = "//app-basket//button[contains(text(),'კალათა')]";

        public static readonly string addProductQuantity = "//i[@class='plus icon-disabled cursor-pointer px-5px']";
        public static readonly string reduceProductQuantity = "//i[@class='minus icon-disabled cursor-pointer px-5px']";

        public static void AddProductInBasket()
        {
            IJavaScriptExecutor js = WebDriver as IJavaScriptExecutor;
            if (js != null)
            {
                js.ExecuteScript("window.scrollBy(0,1050);");
                BaseMethods.WaitSomeInterval(3);
                WebDriver.WaitUntilFindElement(By.XPath(addProductHomePage)).Click();
                js.ExecuteScript("window.scrollBy(0,-1050);");
            }
        }



        public static void DeleteProducts()
        {
            int element = WebDriver.FindElements(findCountProduct).Count;
            for (int i = 0; i < element; i++)
            {
                WebDriver.Click(By.XPath(deleteBasket));
                BaseMethods.WaitSomeInterval(1);
            }
        }

        public static void AddProductQuantity()
        {
            WebDriver.WaitUntilFindElement(By.XPath(addProductQuantity)).Click();
            Assert.IsTrue(CheckMethods.CheckCount(basketProductQuantity, orderProdyctQuantity, WebDriver));
        }

        public static void ReduceProductQuantity()
        {
            WebDriver.WaitUntilFindElement(By.XPath(reduceProductQuantity)).Click();
            Assert.IsTrue(CheckMethods.CheckCount(basketProductQuantity, orderProdyctQuantity, WebDriver));
        }

        public static void GetBasket()
        {
            WebDriver.Click(By.XPath(basketButton));
            WebDriver.WaitUntilFindElement(By.XPath(basketInButton)).Click();

        }

    }
}
