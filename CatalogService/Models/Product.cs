using Shared;

namespace CatalogService.Models
{
    public class Product : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int Stock { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; } = null!;

        public int SupplierId { get; set; }
        public Supplier Supplier { get; set; } = null!;
    }
}
