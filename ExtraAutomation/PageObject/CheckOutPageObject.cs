using ExtraAutomationTesting;
using OpenQA.Selenium;
using SeleniumHelper.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ExtraAutomation.PageObject
{
    class CheckOutPageObject : BaseClass
    {
        private string checkkBalancePayment = "@//*[text()='ბალანსით გადახდა']";

        private static string SearchKeywordInputField = "//div[@id='header']//div//div//div//div//input";
        private static string SearchButton = "//div[@class='rounded-lg search-wrap w-100 h-60px w-100" +
            " bg-gray-550 d-flex align-items-center']//child::button";
        private static string addProductButton = "//button[text()=' კალათაში დამატება ']";
        private static string getBasket = "//span[text()='კალათა']";
        private static string shopButton = "//button[text()=' ყიდვა ']";
        // -----------------------------------------------------------
        public static string OrderCompleteButton = "//button[text()=' შეკვეთის დასრულება ']";
        public static string popupModal = "//*[@id='PopupSignupForm_0']/div[2]/div[1]";
        public static string orderTotalAmount = "//span[text()='პროდუქტების ფასი']/following-sibling::var";
        public static string costOfTheItem = "//span[@class='text-rebeccapurple font-bold font-size-sm-16 font-size-12 d-flex align-items-center']";
        public static string deliveryCost = "//span[text()='მიტანის ღირებულება:']/following-sibling::var";
        // გადახდის მეთოდის მონიშვნა
        public static string paymentMethod = "//span[text()='ბალანსით გადახდა']/preceding-sibling::span";
        public static string PaymentByCardButton = "//span[text()='ბარათით გადახდა']";
        // -      ---------------------------------------------------------------------

        public static void AddProductAndGoToTheCheckoutPage(IWebDriver WebDriver)
        {
            BaseMethods.SendKeys(WebDriver, ElementLocator.Xpath, SearchKeywordInputField, "150764");
            BaseMethods.ClickElement(WebDriver, ElementLocator.Xpath, SearchButton);

            Thread.Sleep(500);
            BaseMethods.ClickElement(WebDriver, ElementLocator.Xpath, addProductButton);

            Thread.Sleep(500);
            BaseMethods.ClickElement(WebDriver, ElementLocator.Xpath, getBasket);

            BaseMethods.ClickElement(WebDriver, ElementLocator.Xpath, shopButton);
        }

        public CheckOutPageObject(IWebDriver webDriver)
        {
            WebDriver = webDriver;
        }
    }
}
