namespace Ecommerce.Models
{
    public class HIstorial
    {
        public int Id { get; set; }
        public User? user { get; set; }
        public Product? Product { get; set; }
        public float PriceValue { get; set; }
        public int Quantity { get; set; }
    }
}