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
            AssertModels(newAccount, personalInfo, nameof(newAccount.Password), nameof(newAccount.Address));
            accountPage.ClickBackButton();

            // Verify address
            accountPage.ClickLink("Addresses");
            accountPage.WaitUntilHeadingVisible("My addresses");
            var addressBox = accountPage.GetAddressText();
            var address = newAccount.Address;
            var propNames = address.GetPropertyNames();
            foreach (var propName in propNames)
            {
                Assert.IsTrue(addressBox.Contains(address.GetPropertyValue(propName).ToString()),
                    $"Current address: {propName} is not exists");
            }
        }
    }
}