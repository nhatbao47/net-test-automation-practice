using NUnit.Framework;
using OpenQA.Selenium;
using System.Linq;
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

        public void AssertModels(object source, object target, params string[] ignoreProps)
        {
            var propNames = source.GetPropertyNames();
            foreach (var propName in propNames)
            {
                if (ignoreProps == null || ignoreProps.Contains(propName)) continue;
                Assert.AreEqual(source.GetPropertyValue(propName), target.GetPropertyValue(propName),
                            $"The '{propName}' is not equals");
            }
        }
    }
}
