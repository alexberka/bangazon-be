namespace bangazon_be.Models
{
    public class OrderProduct
    {
        public int OrderId { get; set; }

        public int ProductId { get; set; }
        public decimal PriceAtSale { get; set; }
        public bool Shipped { get; set; } = false;
    }
}