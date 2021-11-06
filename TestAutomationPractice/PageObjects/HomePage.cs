using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using TestAutomationPractice.Common;
using TestAutomationPractice.Models;

namespace TestAutomationPractice.PageObjects
{
    public class HomePage: BasePage
    {
        public HomePage(IWebDriver driver) : base(driver) { }

        private By _searchTextBox = By.Id("search_query_top");
        private By _searchButton = By.CssSelector("#searchbox button");
        private By _productName = By.CssSelector(".product_list .product-container:first-child .right-block .product-name");
        private By _productPrice = By.CssSelector(".product_list .product-container:first-child .right-block .product-price");

        public void HoverLink(string text)
        {
            var linkSelector = GetLinkLocator(text);
            var link = FindElement(linkSelector);
            if (link == null) return;
            var builder = new Actions(WebDriver);
            builder.MoveToElement(link).Perform();
        }

        public void ClickSubMenu(string menu)
        {
            ClickElement(GetLinkLocator(menu));
        }

        public ProductModel GetFirstProductOnPage()
        {
            var firstProduct = new ProductModel()
            {
                Name = GetElementText(_productName),
                Price = GetElementText(_productPrice)
            };
            return firstProduct;
        }

        public void SearchProduct(string productName)
        {
            SendKeyToElement(_searchTextBox, productName);
            ClickElement(_searchButton);
        }

        private By GetLinkLocator(string text) => By.CssSelector($"a[title^='{text}']");
    }
}
