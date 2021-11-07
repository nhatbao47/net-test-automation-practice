using OpenQA.Selenium;
using TestAutomationPractice.Common;

namespace TestAutomationPractice.Models
{
    public class PropertyLocator
    {
        public PropertyLocator(string propertyName, By elementLocator, ActionType action = ActionType.SendKey)
        {
            PropertyName = propertyName;
            ElementLocator = elementLocator;
            Action = action;
        }

        public string PropertyName { get; set; }
        public By ElementLocator { get; set; }
        public ActionType Action { get; set; }
    }
}
