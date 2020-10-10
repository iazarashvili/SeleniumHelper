using OpenQA.Selenium;


namespace SeleniumHelper.Base
{
    public class Browser 
    {
        private static IWebDriver webDriver;
        public static string GetBrowserUrl(IWebDriver driver)
        {
            string url = webDriver.Url;
            return url;
        }
        public static void BrowserRefresh()
        {
            webDriver.Navigate().Refresh();
        }
        public static void MoveBackward()
        {
            webDriver.Navigate().Back();
        }
        public static void MoveForward()
        {
            webDriver.Navigate().Forward();
        }
    }
}