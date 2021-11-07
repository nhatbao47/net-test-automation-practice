using NUnit.Framework;
using OpenQA.Selenium;
using TestAutomationPractice.Common;
using TestAutomationPractice.PageObjects;

namespace TestAutomationPractice.Common
{
    public class BaseTest
    {
        protected IWebDriver webDriver;
        protected HomePage homePage;

        [SetUp]
        public void SetUp()
        {
            webDriver = WebDriverManagers.CreateBrowserDriver(Browser.Chrome);
            webDriver.Url = Constants.AppUrl;
            homePage = new HomePage(webDriver);
        }

        [TearDown]
        public void TearDown()
        {
            webDriver.Quit();
        }
    }
}
