using OpenQA.Selenium;
using System.Collections.Generic;
using TestAutomationPractice.Common;
using TestAutomationPractice.Models;

namespace TestAutomationPractice.PageObjects
{
    public class AccountPage: BasePage
    {
        private By _registerEmailTextBox = By.Id("email_create");
        private By _createAccountButton = By.Id("SubmitCreate");
        private By _registerButton = By.Id("submitAccount");
        private By _backButton = By.XPath("//li/a/span[contains(.,'Back to your account')]");
        private By _addressBox = By.CssSelector("div.addresses");

        public AccountPage(IWebDriver driver) : base(driver) { }

        public void InputRegisterEmail(string emailAdress) => SendKeyToElement(_registerEmailTextBox, emailAdress);

        public void ClickCreateAccountButton()
        {
            ClickElement(_createAccountButton);
        }

        public void WaitUntilHeadingVisible(string heading) => WaitForElementVisible(By.XPath($"//h1[contains(text(), '{heading}')]"));

        public AccountModel GenerateNewAccount()
        {
            return new AccountModel()
            {
                FirstName = "William",
                LastName = "M Davenport",
                EmailAddress = StringUtil.GetSaltString() + "@local.com",
                Password = "123456",
                Address = new AddressModel()
                {
                    FirstName = "William",
                    LastName = "M Davenport",
                    Address = "3253 Franklin Street",
                    City = "Montgomery",
                    State = "Alabama",
                    ZipCode = "36104",
                    MobilePhone = "334-516-7823",
                    AddressAlias = "3253 Franklin Street"
                }
            };
        }

        public void InputAccountDetails(AccountModel account)
        {
            InputFields(GetInputPersonalLocators(), account);
            InputFields(GetInputAddressLocators(), account.Address);
        }

        public void ClickRegisterButton() => ClickElement(_registerButton);

        public void ClickBackButton() => ClickElement(_backButton);

        public AccountModel GetPersonalInformation()
        {
            var person = new AccountModel();
            person.FirstName = GetElementValue(By.Id("firstname"));
            person.LastName = GetElementValue(By.Id("lastname"));
            person.EmailAddress = GetElementValue(By.Id("email"));
            return person;
        }

        public string GetAddressText() => GetElementText(_addressBox);

        private void InputFields(List<PropertyLocator> inputLocators, object dataObject)
        {
            foreach (var input in inputLocators)
            {
                var text = dataObject.GetPropertyValue(input.PropertyName).ToString();
                switch (input.Action)
                {
                    case ActionType.SendKey:
                        SendKeyToElement(input.ElementLocator, text);
                        break;
                    case ActionType.Select:
                        SelectElement(input.ElementLocator, text);
                        break;
                }
            }
        }

        private List<PropertyLocator> GetInputPersonalLocators()
        {
            return new List<PropertyLocator>()
            {
                new PropertyLocator(nameof(AccountModel.FirstName), By.Id("customer_firstname")),
                new PropertyLocator(nameof(AccountModel.LastName), By.Id("customer_lastname")),
                new PropertyLocator(nameof(AccountModel.EmailAddress), By.Id("email")),
                new PropertyLocator(nameof(AccountModel.Password), By.Id("passwd"))
            };
        }

        private List<PropertyLocator> GetInputAddressLocators()
        {
            return new List<PropertyLocator>()
            {
                new PropertyLocator(nameof(AddressModel.FirstName), By.Id("firstname")),
                new PropertyLocator(nameof(AddressModel.LastName), By.Id("lastname")),
                new PropertyLocator(nameof(AddressModel.Address), By.Id("address1")),
                new PropertyLocator(nameof(AddressModel.City), By.Id("city")),
                new PropertyLocator(nameof(AddressModel.State), By.Id("id_state"), ActionType.Select),
                new PropertyLocator(nameof(AddressModel.ZipCode), By.Id("postcode")),
                new PropertyLocator(nameof(AddressModel.MobilePhone), By.Id("phone_mobile")),
                new PropertyLocator(nameof(AddressModel.AddressAlias), By.Id("alias"))
            };
        }
    }
}