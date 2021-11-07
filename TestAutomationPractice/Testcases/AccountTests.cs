using NUnit.Framework;
using TestAutomationPractice.Common;

namespace TestAutomationPractice.Testcases
{
    [TestFixture]
    public class AccountTests: BaseTest
    {
        [Test]
        public void RegisterNewAccount()
        {
            var accountPage = homePage.ClickSignInButton();
            var newAccount = accountPage.GenerateNewAccount();
            accountPage.InputRegisterEmail(newAccount.EmailAddress);
            accountPage.ClickCreateAccountButton();
            accountPage.WaitUntilHeadingVisible("Create an account");
            accountPage.InputAccountDetails(newAccount);
            accountPage.ClickRegisterButton();
            accountPage.WaitUntilHeadingVisible("My account");
            accountPage.ClickLink("Information");
            accountPage.WaitUntilHeadingVisible("Your personal information");

            // Verify personal information
            var personalInfo = accountPage.GetPersonalInformation();
            Assert.AreEqual(newAccount.FirstName, personalInfo.FirstName);
            Assert.AreEqual(newAccount.LastName, personalInfo.LastName);
            Assert.AreEqual(newAccount.EmailAddress, personalInfo.EmailAddress);
            accountPage.ClickBackButton();

            // Verify address
            accountPage.ClickLink("Addresses");
            accountPage.WaitUntilHeadingVisible("My addresses");
            var addressBox = accountPage.GetAddressText();
            var address = newAccount.Address;
            Assert.IsTrue(addressBox.Contains(address.FirstName), "The primary address' first name is not exists");
            Assert.IsTrue(addressBox.Contains(address.LastName), "The primary address' last name is not exists");
            Assert.IsTrue(addressBox.Contains(address.Address), "The primary address is not exists");
            Assert.IsTrue(addressBox.Contains(address.City), "The primary address' city is not exists");
            Assert.IsTrue(addressBox.Contains(address.State), "The primary address' state is not exists");
            Assert.IsTrue(addressBox.Contains(address.ZipCode), "The primary address' zipcode is not exists");
            Assert.IsTrue(addressBox.Contains(address.MobilePhone), "The primary address' mobile phone is not exists");
        }
    }
}