using Shared;

namespace CatalogService.Models
{
    public class Supplier : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public  string? ContactEmail { get; set; }
        public List<Product> Products { get; set; } = new();
    }
}
