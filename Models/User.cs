namespace bangazon_be.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string? Address { get; set; }
        public string? Email { get; set; }
        public string Uid { get; set; }
        public List<Product> Products { get; set; }
        public List<Order> Orders { get; set; }
    }
}