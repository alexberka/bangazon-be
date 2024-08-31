namespace bangazon_be.Models
{

    public class Product
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public int Quantity { get; set; } = 0;
        public int CategoryId { get; set; }
        public decimal Price { get; set; } = 0.00m;
        public int SellerId { get; set; }
        public List<Order> Orders { get; set; }
    }
}
