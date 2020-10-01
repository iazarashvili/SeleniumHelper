using System;
using System.Collections.Generic;
using System.Text;

namespace ExtraAutomation
{
    public class PaymentsLocators
    {
        public static string SearchInput = "//div[@id='header']//div//div//div//div//input";
        public static string SearchButton = "//div[@class='rounded-lg search-wrap w-100 h-60px w-100" +
            " bg-gray-550 d-flex align-items-center']//child::button";
        public static string addProductButton = "//button[text()=' კალათაში დამატება ']";
        public static string getBasket = "//span[text()='კალათა']";
        public static string shopButton = "//button[text()=' ყიდვა ']";

        public static string PaymentByCardButton = "//span[text()='ბარათით გადახდა']";
        public static string OrderCompleteButton = "//button[text()=' შეკვეთის დასრულება ']";

        public static string popupModal = "//*[@id='PopupSignupForm_0']/div[2]/div[1]";

        public static string orderTotalAmount = "//span[@class='text-rebeccapurple font-bold font-size-16 d-flex align-items-center']";
        public static string costOfTheItem = "//span[@class='text-rebeccapurple font-bold font-size-sm-16 font-size-12 d-flex align-items-center']";
        public static string cityName = "//span[@class='ng-value-label']";
        public static string deliveryCost = "//span[text()='მიტანის ღირებულება:']/following-sibling::var";
    }
}
