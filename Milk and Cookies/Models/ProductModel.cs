namespace Milk_and_Cookies.Models
{
    public class ProductModel
    {
        public ProductModel(string name, double price)
        {
            Name = name;
            Price = price;
        }

        public string Name { get; set; }
        public double Price { get; set; }
    }
}
