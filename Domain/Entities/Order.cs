using ecommerceAPI.Domain.Enums;

namespace ecommerceAPI.Domain.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime CreatedAt { get; set; }
        public OrderStatus Status { get; set; }
      
        public User User { get; set; }
        public ICollection<OrderItem> Items { get; set; }

    }
}
