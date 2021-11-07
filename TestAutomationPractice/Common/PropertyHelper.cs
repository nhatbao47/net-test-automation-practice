using System.Reflection;

namespace TestAutomationPractice.Common
{
    public static class PropertyHelper
    {
        public static object GetPropertyValue<T>(this T classInstance, string propertyName)
        {
            PropertyInfo property = classInstance.GetType().GetProperty(propertyName);
            if (property != null)
                return property.GetValue(classInstance, null);
            return null;
        }
    }
}
