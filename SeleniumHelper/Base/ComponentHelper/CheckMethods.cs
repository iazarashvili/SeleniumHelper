using System;
using System.Globalization;
using System.Linq;
using OpenQA.Selenium;
using SeleniumHelper.Base;


namespace SeleniumHelper.ComponentHelper
{
    public class CheckMethods
    {
        public static bool CheckValidLogin(IWebDriver driver, string locator)
        {
            try
            {
                BaseMethods.WaitTillElementDisplayed(driver, locator, ElementLocator.Xpath);
                return true;
            }
            catch (NotFoundException ex)
            {
                Console.WriteLine("Username not found" , ex);
                return false;
            }
        }
        public static bool CheckCount(string first, string last , IWebDriver WebDriver)
        {
            IWebElement cartCount = BaseMethods.WaitElement(WebDriver, ElementLocator.Xpath, first);
            IWebElement orderCount = BaseMethods.WaitElement(WebDriver, ElementLocator.Xpath, last);
            int cartNumber = int.Parse(cartCount.Text);
            int orderNumber = int.Parse(orderCount.Text);
            if (cartNumber == orderNumber)
            {
                return true;
            }
            return false;
        }

        public static bool CheckPaymentMethod(string orderTotalAmount, string costOfTheItem ,string deliveryCost, IWebDriver webdriver)
        {
            IWebElement orderPrice = BaseMethods.WaitElement(webdriver, ElementLocator.Xpath, orderTotalAmount);
            decimal priceOrder = decimal.Parse(orderPrice.Text, NumberStyles.Any);

            IWebElement itemPrice = BaseMethods.WaitElement(webdriver, ElementLocator.Xpath, costOfTheItem);
            decimal priceItem = decimal.Parse(itemPrice.Text, NumberStyles.Any);

            IWebElement deliveryPrice = BaseMethods.WaitElement(webdriver, ElementLocator.Name, deliveryCost);

            string first = deliveryPrice.Text;
            string[] word = first.Split('₾');
            int delivery = int.Parse(word[0], NumberStyles.Any);

            if ((delivery == 0) && (priceOrder == priceItem))
            {
                return true;
            }
            if((delivery == 5) && (priceOrder < priceItem ))
            {
                return true;
            }
            return false;
        }   
        public static void CheckedAndUncheckedBoxes(IWebDriver webDriver, string paymentMethod)
        {
            
        }
    }
}