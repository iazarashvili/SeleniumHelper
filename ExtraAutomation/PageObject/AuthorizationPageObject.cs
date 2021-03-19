﻿using ExtraAutomationTesting;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumHelper.Base;
using SeleniumHelper.ComponentHelper;
using System;

namespace ExtraAutomation.PageObject
{
    class AuthorizationPageObject : BaseClass
    {

        private string EnterUserName = "tapey73486@yutongdt.com";

        private string EnterPassword = "Extra2020";

        private static string LoginInputButton = "//input[@placeholder='ტელეფონი ან ელ.ფოსტა']";
        private static string PasswordInput = "//input[@placeholder='პაროლი']";
        private static string LogginButton = "//span[text()=' შესვლა']";
        private static string checkedlocator = "//span[contains(text(),' ilia')]";


        public HomePageObject Login()
        {
            try
            {
                Assert.AreEqual(WebDriver.Title, "🌈 Extra.ge - რაც გაგიხარდება");
                BaseMethods.WaitDispleed(WebDriver, ElementLocator.Xpath, LoginInputButton);
                BaseMethods.SendKeys(WebDriver, ElementLocator.Xpath, LoginInputButton, EnterUserName);
                BaseMethods.SendKeys(WebDriver, ElementLocator.Xpath, PasswordInput, EnterPassword);
                BaseMethods.ClickElement(WebDriver, ElementLocator.Xpath, LogginButton);
                Assert.IsTrue(CheckMethods.CheckValidLogin(WebDriver, checkedlocator));

                return new HomePageObject(WebDriver);

            }
            catch (ElementNotVisibleException e)
            {
                Console.WriteLine("Test failded", e.Message);
            }
            return new HomePageObject(WebDriver);
        }


        public AuthorizationPageObject(IWebDriver webDriver)
        {
            WebDriver = webDriver;
        }
    }

}
