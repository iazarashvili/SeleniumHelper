using OpenQA.Selenium;
using System;
using System.Globalization;

namespace SeleniumHelper.Base
{
    public class CheckMethods
    {
        public static bool CheckValidLogin(IWebDriver driver, string locator)
        {
            try
            {
                BaseMethods.WaitDispleed(driver, ElementLocator.Xpath, locator);
                return true;
            }
            catch (NotFoundException ex)
            {
                Console.WriteLine("Username not found" + ex.Message);
                return false;
            }
        }
        public static bool CheckCount(string? basketProductQuantity, string? orderProdyctQuantity, IWebDriver webDriver)
        {
            var cartCount = BaseMethods.WaitElementIsVisibleReturn(webDriver, ElementLocator.Xpath, basketProductQuantity);
            var cartNumber = int.Parse(cartCount.Text);

            var orderCount = BaseMethods.WaitElementIsVisibleReturn(webDriver, ElementLocator.Xpath, orderProdyctQuantity);
            var orderNumber = int.Parse(orderCount.Text);

            if (cartNumber == orderNumber) return true;
            return false;
        }

        public static bool CheckPaymentMethod(string orderTotalAmount, string costOfTheItem, string deliveryCost, IWebDriver webDriver)
        {
            var orderPrice = BaseMethods.WaitElementIsVisibleReturn(webDriver, ElementLocator.Xpath, orderTotalAmount);
            var priceOrder = decimal.Parse(orderPrice.Text, NumberStyles.Any);

            var itemPrice = BaseMethods.WaitElementIsVisibleReturn(webDriver, ElementLocator.Xpath, costOfTheItem);
            var priceItem = decimal.Parse(itemPrice.Text, NumberStyles.Any);

            var deliveryPrice = BaseMethods.WaitElementIsVisibleReturn(webDriver, ElementLocator.Xpath, deliveryCost);

            if ("უფასო" == deliveryPrice.Text && priceOrder == priceItem)
            {
                Console.WriteLine("The price of the products and the amount to be paid are correct");
                return true;
            }
            var basketProductQuantity = deliveryPrice.Text;
            var word = basketProductQuantity.Split('₾');
            decimal delivery = int.Parse(word[0], NumberStyles.Any);

            if (delivery == 0 && priceOrder == priceItem)
            {
                Console.WriteLine("The price of the products and the amount to be paid are correct");
                return true;
            }

            if (delivery == 7 && priceOrder < priceItem)
            {
                Console.WriteLine("The price of the products and the amount to be paid are correct");
                return true;
            }
            Console.WriteLine("The price of the products and the amount to be paid are not correct");
            return false;
        }
        public static void ClickCheckBox(IWebElement element)
        {
            element.Click();
        }

        public static bool IsCheckBoxChecked(IWebElement element)
        {
            var flag = element.GetAttribute("checked");
            if (flag == null)
                return false;
            else
                return true;
        }

        public static bool IsCheckBoxEnbaled(IWebElement element)
        {
            return element.Enabled;
        }
    }

}
