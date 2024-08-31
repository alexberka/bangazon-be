namespace bangazon_be.Models
{
    public class OrderProduct
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public decimal PriceAtSale { get; set; } = 0.00m;
        public bool Shipped { get; set; } = false;
        public Order? Order { get; set; }
        public Product? Product { get; set; }
    }
}