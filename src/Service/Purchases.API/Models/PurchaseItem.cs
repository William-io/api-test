using System.ComponentModel.DataAnnotations;

namespace Purchases.API.Models
{
    public class PurchaseItem
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
