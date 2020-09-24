using ExtraAutomationTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExtraAutomation.TestCases
{
    class PaymantMethodIPay : BaseClass
    {
        public static string SearchInput = "//div[@id='header']//div//div//div//div//input";
        public static string SearchButton = "//div[@class='rounded-lg search-wrap w-100 h-60px w-100" +
            " bg-gray-550 d-flex align-items-center']//child::button";
        public static string AddProduct = "//button[text()=' კალათაში დამატება ']";
        public static string Basket = "//span[text()='კალათა']";
        public static string ShopButton = "//button[text()=' ყიდვა ']";

        public static string PaymentByCardButton = "//span[text()='ბარათით გადახდა']";
        public static string OrderCompleteButton = "//button[text()=' შეკვეთის დასრულება ']";

        public void PaymantTestIpay()
        {
            var login = new Login(WebDriver);
            login.TestLogin();
        }
    }
}
