using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce.Models
{
    public class HIstorial
    {
        public int Id { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public User? User { get; set; }

        public DateTime? DatePusrchase { get; set; }

        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public Product? Product { get; set; }
        public float PriceValue { get; set; }
        public int Quantity { get; set; }
    }
}