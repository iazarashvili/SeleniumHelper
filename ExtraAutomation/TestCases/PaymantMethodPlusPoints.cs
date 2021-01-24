using ExtraAutomation.PageObject;
using ExtraAutomationTesting;
using NUnit.Framework;
using SeleniumHelper.Base;
using SeleniumHelper.ComponentHelper;

namespace ExtraAutomation.TestCases
{
    class PaymantMethodPlusPoints : BaseClass
    {
      
        [Test, Category("Paymant Test PlusPoints")]
        public void PaymantPlusPoint()
        {
            var signIn = new HomePageObject(WebDriver)
                    .SignIn()
                    .Login();
            CheckOutPageObject.AddProductAndGoToTheCheckoutPage(WebDriver, ElementLocator.Xpath, CheckOutPageObject.PaymentByPlusPoint);
            Assert.True(CheckMethods.CheckPaymentMethod(CheckOutPageObject.orderTotalAmount,
                CheckOutPageObject.costOfTheItem, CheckOutPageObject.deliveryCost, WebDriver));
            BaseMethods.ClickElement(WebDriver, ElementLocator.Xpath, CheckOutPageObject.OrderCompleteButton);
            
        }
    }
}
