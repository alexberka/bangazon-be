using bangazon_be.Models;

namespace bangazon_be.Dtos
{
    public record NewUserDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string? Address { get; set; }
        public string? Email { get; set; }
        public string Uid { get; set; }
    }
}