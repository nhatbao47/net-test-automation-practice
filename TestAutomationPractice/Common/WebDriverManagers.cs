using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using WebDriverManager.DriverConfigs.Impl;

namespace TestAutomationPractice.Common
{
    public class WebDriverManagers
    {
        public static IWebDriver CreateBrowserDriver(Browser browser)
        {
            IWebDriver driver = null;

            switch (browser)
            {
                case Browser.Firefox:
                    new WebDriverManager.DriverManager().SetUpDriver(new FirefoxConfig());
                    driver = new FirefoxDriver();
                    break;
                case Browser.Chrome:
                    new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
                    driver = new ChromeDriver();
                    break;
                case Browser.Edge:
                    new WebDriverManager.DriverManager().SetUpDriver(new EdgeConfig());
                    driver = new EdgeDriver();
                    break;
            }
            driver.Manage().Window.Maximize();
            return driver;
        }
    }
}
