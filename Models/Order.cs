namespace bangazon_be.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public User Customer { get; set; }
        public DateTime? CompletionDate { get; set; } = null;
        public decimal TotalCost { get; set; }
        public string? PaymentType { get; set; }
        public List<Product> Products { get; set; }
        public List<OrderProduct> OrderProducts { get; set; }
    }
}
