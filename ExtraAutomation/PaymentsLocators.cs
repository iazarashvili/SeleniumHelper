using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExtraAutomation
{
    public class PaymentsLocators
    {
        
        public static string SearchKeywordInputField = "//div[@id='header']//div//div//div//div//input";
        public static string SearchButton = "//div[@class='rounded-lg search-wrap w-100 h-60px w-100" +
            " bg-gray-550 d-flex align-items-center']//child::button";
        public static string addProductButton = "//button[text()=' კალათაში დამატება ']";
        public static string getBasket = "//span[text()='კალათა']";
        public static string shopButton = "//button[text()=' ყიდვა ']";

        public static string PaymentByCardButton = "//span[text()='ბარათით გადახდა']";
        public static string OrderCompleteButton = "//button[text()=' შეკვეთის დასრულება ']";

        public static string popupModal = "//*[@id='PopupSignupForm_0']/div[2]/div[1]";

        //პროდუქტების ფასი
        public static string orderTotalAmount = "//span[text()='პროდუქტების ფასი']/following-sibling::var";
        //სულ თანხა
        public static string costOfTheItem = "//span[@class='text-rebeccapurple font-bold font-size-sm-16 font-size-12 d-flex align-items-center']";
        
        public static string deliveryCost = "//var[contains(text(),'5 ₾')]";
       
        //ბალანსით გადახდის მეთოდის მონიშვნა
        public static string paymentMethod = "//span[text()='ბალანსით გადახდა']/preceding-sibling::span";
    }
}
