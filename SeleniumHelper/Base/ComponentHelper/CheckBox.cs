using OpenQA.Selenium;

namespace SeleniumHelper.Base
{
    public static class CheckBox
    {
        public static void ClickCheckBox(IWebElement element)
        {
            element.Click();
        }
        
        public static bool IsCheckboxChecked(IWebElement element)
        {
            string flag = element.GetAttribute("checked");
            if (flag == null)
            {
                return false;
            }
            else
                return true;
        }

        public static bool IsCheckboxEnbaled(IWebElement element)
        {
            return element.Enabled;
        }
        
    }
}