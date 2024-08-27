namespace bangazon_be.Models
{

    public class Product
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public int Quantity { get; set; }
        public int CategoryId { get; set; }
        public decimal Price { get; set; }
        public int SellerId { get; set; }
        public List<Order> Orders { get; set; }
    }
}
