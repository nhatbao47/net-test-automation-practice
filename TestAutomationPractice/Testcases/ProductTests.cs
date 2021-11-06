using NUnit.Framework;
using TestAutomationPractice.TestCases;

namespace TestAutomationPractice.Testcases
{
    [TestFixture]
    public class ProductTests: BaseTest
    {
        [Test]
        public void SearchProduct()
        {
            homePage.HoverLink("Women");
            homePage.ClickSubMenu("T-shirts");
            homePage.WaitUntilPageReady();
            var firstProduct = homePage.GetFirstProductOnPage();
            homePage.SearchProduct(firstProduct.Name);
            homePage.WaitUntilPageReady();
            var result = homePage.GetFirstProductOnPage();
            Assert.IsTrue(firstProduct.IsEqual(result), "They are difference");
        }
    }
}
