using OpenQA.Selenium;
using SeleniumHelper.Base;

namespace ExtraAutomation.PageObject
{
    class CheckOutPageObject : BaseClass
    {


        public static readonly string SearchKeywordInputField = "//div[@id='header']//div//div//div//div//input";
        public static readonly string SearchButton = "//div[@class='_s_size-w-percent--20 _s_display-n _s_md-display-f _s_flex-a-center']//i[1]";
        public static readonly string addProductButton = "//button[text()=' კალათაში დამატება ']";
        public static readonly string getBasket = "//span[text()='კალათა']";
        public static readonly string shopButton = "//button[text()=' ყიდვა ']";
        // -----------------------------------------------------------
        public static readonly string OrderCompleteButton = "//button[text()=' შეკვეთის დასრულება ']";
        public static readonly string popupModal = "//*[@id='PopupSignupForm_0']/div[2]/div[1]";
        public static readonly string orderTotalAmount = "//span[text()='პროდუქტების ფასი']/following-sibling::var";
        public static readonly string costOfTheItem = "//span[@class='text-rebeccapurple font-bold font-size-sm-16 font-size-12 d-flex align-items-center']";
        public static readonly string deliveryCost = "//span[text()='მიტანის ღირებულება:']/following-sibling::var";

        // Payment Methods
        public static readonly string PaymentByCardIpay = "//span[text()='ბარათით გადახდა']";
        public static readonly string PaymentByCourier = "//span[text()='კურიერთან გადახდა']";
        public static readonly string PaymentByBalance = "//span[text()='ბალანსით გადახდა']";
        public static readonly string PaymentByPlusPoint = "//span[text()='Plus ქულებით გადახდა']";
        public static readonly string PaymentByMc = "//span[text()='Mastercard ფასდაკლება']";

        // -      ---------------------------------------------------------------------

        public static void AddProductAndGoToTheCheckoutPage(IWebDriver webDriver, ElementLocator element, string paymentMethod)
        {
            BaseMethods.SendKeys(webDriver, ElementLocator.Xpath, SearchKeywordInputField, "101757");
            BaseMethods.ClickElement(webDriver, ElementLocator.Xpath, SearchButton);

            BaseMethods.ClickElement(webDriver, ElementLocator.Xpath, addProductButton);

            BaseMethods.ClickElement(webDriver, ElementLocator.Xpath, getBasket);

            BaseMethods.ClickElement(webDriver, ElementLocator.Xpath, shopButton);

            BaseMethods.ClickElement(webDriver, ElementLocator.Xpath, paymentMethod);

        }
    }
}
