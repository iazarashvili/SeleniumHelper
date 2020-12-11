﻿using System;
using System.Globalization;
using System.Linq;
using NUnit.Framework;
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
                BaseMethods.WaitDispleed(driver, ElementLocator.Xpath, locator);
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
            IWebElement cartCount = BaseMethods.WaitElementIsVisibleReturn(WebDriver, ElementLocator.Xpath, first);
            IWebElement orderCount = BaseMethods.WaitElementIsVisibleReturn(WebDriver, ElementLocator.Xpath, last);
            int cartNumber = int.Parse(cartCount.Text);
            int orderNumber = int.Parse(orderCount.Text);
            if (cartNumber == orderNumber)
            {
                return true;
            }
            return false;
        }

        public static bool CheckPaymentMethod(string orderTotalAmount, string costOfTheItem, string deliveryCost, IWebDriver webdriver)
        {
            IWebElement orderPrice = BaseMethods.WaitElementIsVisibleReturn(webdriver, ElementLocator.Xpath, orderTotalAmount);
            decimal priceOrder = decimal.Parse(orderPrice.Text, NumberStyles.Any);

            IWebElement itemPrice = BaseMethods.WaitElementIsVisibleReturn(webdriver, ElementLocator.Xpath, costOfTheItem);
            decimal priceItem = decimal.Parse(itemPrice.Text, NumberStyles.Any);

            IWebElement deliveryPrice = BaseMethods.WaitElementIsVisibleReturn(webdriver, ElementLocator.Name, deliveryCost);
          
            //Assert.AreEqual("უფასო", BaseMethods.findElement(webdriver, ElementLocator.Xpath, deliveryCost).Text);


            string first = deliveryPrice.Text;
            string[] word = first.Split('₾');
            if (Assert.AreEqual("უფასო", BaseMethods.findElement(webdriver, ElementLocator.Xpath, deliveryCost).Text))
            {
                return true;
            }
            decimal delivery = int.Parse(word[0], NumberStyles.Any);

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