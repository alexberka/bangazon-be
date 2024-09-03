using Microsoft.EntityFrameworkCore;
using bangazon_be.Models;
using Microsoft.Extensions.Hosting;

public class BangazonBeDbContext : DbContext
{
    public DbSet<Category> Categories { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderProduct> OrderProducts { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<User> Users { get; set; }

    public BangazonBeDbContext() { }
    public BangazonBeDbContext(DbContextOptions<BangazonBeDbContext> context) : base(context)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Order>()
            .HasMany(e => e.Products)
            .WithMany(e => e.Orders)
            .UsingEntity<OrderProduct>();

        modelBuilder.Entity<Category>().HasData(new Category[]
            {
                new() { Id = 1, Name = "Home Goods" },
                new() { Id = 2, Name = "Health" },
                new() { Id = 3, Name = "Entertainment" },
                new() { Id = 4, Name = "Clothing" },
                new() { Id = 5, Name = "Plants" }
            });

        modelBuilder.Entity<User>().HasData(new User[]
            {
                new() { Id = 1, FirstName = "Steven", LastName = "Murray", Username = "cspan_warrior", Address = "423 Friday Ln, Westdale, AL", Uid = "76FJhdpekly73k7K"},
                new() { Id = 2, FirstName = "Hailey", LastName = "Finnegan", Username = "darkwingduck133", Address = "17324 Chamomile Dr, Harley Falls, VT", Uid = "RplI9hf723kvcZZs"},
                new() { Id = 3, FirstName = "Cassie", LastName = "Thomas", Username = "albionblonde", Address = "2413 Main St, Finley, AZ", Uid = "hhfYm734hN1mdifE"},
                new() { Id = 4, FirstName = "Atticus", LastName = "Parker", Username = "atticusparker", Address = "9230 Christiansen Pk, Sharpsville, MD", Uid = "muIE7340mEE223Id"}
            });


        modelBuilder.Entity<Order>().HasData(new Order[]
        {
            new() { Id = 1, CustomerId = 3, CompletionDate = new DateTime(2024, 08, 25), TotalCost = 51.24m, PaymentType = "Paypal" },
            new() { Id = 2, CustomerId = 2}
        });


        modelBuilder.Entity<Product>().HasData(new Product[]
        {
            new() { Id = 1, Title = "Solar Turkey Chopper", Description = "For those sunny Thanksgiving picnics", Quantity = 16, CategoryId = 1, Price = 14.70m, SellerId = 4 },
            new() { Id = 2, Title = "Heathered Mindfulness Ankle Socks (1-pair)", Description = "50% cotton-polyester blend, 45% rayon-styrene blend, 4% elastic, 1% braided titanium", Quantity = 76, CategoryId = 4, Price = 7.04m, SellerId = 4 },
            new() { Id = 3, Title = "Ace Ventura: Pet Detective (1994) DVD", Description = "Zany pet detective Ace Ventura (Jim Carrey) looks investigates a missing mascot.", Quantity = 4, CategoryId = 3, Price = 37.16m, SellerId = 4 },
            new() { Id = 4, Title = "18-pack Clean-x Facial Tissue", Description = "Very good soft", Quantity = 2530, CategoryId = 2, Price = 59.87m, SellerId = 4 }
        });

        modelBuilder.Entity<OrderProduct>().HasData(new OrderProduct[]
        {
            new() { Id = 1, OrderId = 1, ProductId = 2, PriceAtSale = 7.04m, Shipped = true },
            new() { Id = 2, OrderId = 1, ProductId = 2, PriceAtSale = 7.04m, Shipped = true },
            new() { Id = 3, OrderId = 1, ProductId = 3, PriceAtSale = 37.16m, Shipped = true },
            new() { Id = 4, OrderId = 2, ProductId = 4},
            new() { Id = 5, OrderId = 2, ProductId = 3}
        });
    }
}