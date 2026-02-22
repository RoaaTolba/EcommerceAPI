namespace ecommerceAPI.Domain.Entities
{
    public class CartItem
    {
        public int Id { get; set; }
        public int CartId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }

        //navigation property
        public Cart Cart { get; set; }
        public Order product { get; set; }
    }
}
