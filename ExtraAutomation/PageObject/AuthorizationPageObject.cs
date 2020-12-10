using ExtraAutomationTesting;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumHelper.Base;
using SeleniumHelper.ComponentHelper;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExtraAutomation.PageObject
{
    class AuthorizationPageObject : BaseClass
    {
        private IWebDriver _webdriver;

        public static string MyEmail = "595300019";
        public static string MyPassword = "Extra2020";
        public static string LoginInputButton = "//input[@placeholder='ტელეფონი ან ელ.ფოსტა']";
        public static string PasswordInput = "//input[@placeholder='პაროლი']";
        public static string LogginButton = "//app-sign-in-page//button[text()=' შესვლა ']";
        private static string checkedlocator = "//span[contains(text(),'ტესტ ')]";


        public AuthorizationPageObject(IWebDriver webDriver)
        {
            _webdriver = webDriver;
        }

        public HomePageObject Login()
        {
            //BaseMethods.Wait(WebDriver, ElementLocator.Xpath, LoginInputButton);
            //BaseMethods.Wait(WebDriver, ElementLocator.Xpath, PasswordInput);
            //BaseMethods.SendKeys(WebDriver, ElementLocator.Xpath, LoginInputButton, MyEmail);
            //BaseMethods.SendKeys(WebDriver, ElementLocator.Xpath, PasswordInput, MyPassword);
            //BaseMethods.Click(WebDriver, ElementLocator.Xpath, LogginButton);
            //Assert.IsTrue(CheckMethods.CheckValidLogin(WebDriver, checkedlocator));
            try
            {
               if (BaseMethods.Wait(WebDriver, ElementLocator.Xpath, LoginInputButton, 12) &&
                    BaseMethods.Wait(WebDriver, ElementLocator.Xpath, PasswordInput, 12))
                  {
                    BaseMethods.SendKeys(WebDriver, ElementLocator.Xpath, LoginInputButton, MyEmail);
                    BaseMethods.SendKeys(WebDriver, ElementLocator.Xpath, PasswordInput, MyPassword);
                    BaseMethods.Click(WebDriver, ElementLocator.Xpath, LogginButton);
                    Assert.IsTrue(CheckMethods.CheckValidLogin(WebDriver, checkedlocator));
                    return new HomePageObject(_webdriver);
                }
                else
                {
                    Console.WriteLine("Login Test Failed.");
                    Console.WriteLine("UsernameField, PasswordField or LoginBtn not found.");
                }
                Console.WriteLine("Login test Sucsess");
            }
            catch (ElementNotVisibleException e)
            {
                Console.WriteLine("Test failded", e.Message);
            }
            return new HomePageObject(_webdriver);
        }

            
        }

    }

