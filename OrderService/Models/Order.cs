using Shared;

namespace OrderService.Models
{
    public class Order : BaseEntity
    {
        public Guid UserPublicId { get; set; }
        public decimal Total { get; set; }
        public List<OrderItem> Items { get; set; }
    }
}
