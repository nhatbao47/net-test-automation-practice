namespace TestAutomationPractice.Models
{
    public class ProductModel
    {
        public string Name { get; set; }
        public string Price { get; set; }

        public bool IsEqual(ProductModel other)
            => string.Equals(Name, other.Name) && string.Equals(Price, other.Price);
    }
}
