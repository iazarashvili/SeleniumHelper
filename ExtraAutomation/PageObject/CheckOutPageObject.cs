using OpenQA.Selenium;
using SeleniumHelper.Base;

namespace ExtraAutomation.PageObject
{
    class CheckOutPageObject : BaseClass
    {


        private const string SearchKeywordInputField = "//div[@id='header']//div//div//div//div//input";
        private const string SearchButton = "//div[@class='_s_size-w-percent--20 _s_display-n _s_md-display-f _s_flex-a-center']//i[1]";
        private const string AddProductButton = "//button[text()=' კალათაში დამატება ']";
        private const string GetBasket = "//span[text()='კალათა']";
        private const string ShopButton = "//button[text()=' ყიდვა ']";
        // -----------------------------------------------------------
        protected const string OrderCompleteButton = "//button[text()=' შეკვეთის დასრულება ']";
        protected const string OrderTotalAmount = "//span[text()='პროდუქტების ფასი']/following-sibling::var";
        protected const string CostOfTheItem = "//span[@class='text-rebeccapurple font-bold font-size-sm-16 font-size-12 d-flex align-items-center']";
        protected const string DeliveryCost = "//span[text()='მიტანის ღირებულება:']/following-sibling::var";

        // Payment Methods
        protected const string PaymentByCardIpay = "//span[text()='ბარათით გადახდა']";
        protected const string PaymentByCourier = "//span[text()='კურიერთან გადახდა']";
        protected const string PaymentByBalance = "//span[text()='ბალანსით გადახდა']";
        protected const string PaymentByPlusPoint = "//span[text()='Plus ქულებით გადახდა']";
        protected const string PaymentByMc = "//span[text()='Mastercard ფასდაკლება']";

        // -      ---------------------------------------------------------------------

        public static void AddProductAndGoToTheCheckoutPage(IWebDriver webDriver, ElementLocator element, string paymentMethod)
        {
            BaseMethods.SendKeys(webDriver, ElementLocator.Xpath, SearchKeywordInputField, "101757");
            BaseMethods.ClickElement(webDriver, ElementLocator.Xpath, SearchButton);

            BaseMethods.ClickElement(webDriver, ElementLocator.Xpath, AddProductButton);

            BaseMethods.ClickElement(webDriver, ElementLocator.Xpath, GetBasket);

            BaseMethods.ClickElement(webDriver, ElementLocator.Xpath, ShopButton);

            BaseMethods.ClickElement(webDriver, ElementLocator.Xpath, paymentMethod);

        }
    }
}
