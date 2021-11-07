using NUnit.Framework;
using TestAutomationPractice.Common;

namespace TestAutomationPractice.Testcases
{
    [TestFixture]
    public class ProductTests: BaseTest
    {
        [Test]
        public void SearchProduct()
        {
            homePage.HoverLink("Women");
            homePage.ClickLink("T-shirts");
            homePage.WaitUntilPageReady();
            var firstProduct = homePage.GetFirstProductOnPage();
            homePage.SearchProduct(firstProduct.Name);
            homePage.WaitUntilPageReady();
            var result = homePage.GetFirstProductOnPage();
            AssertModels(firstProduct, result);
        }
    }
}
