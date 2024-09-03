using Microsoft.EntityFrameworkCore;
using bangazon_be.Models;

namespace bangazon_be.Apis
{
    public class ProductsApi
    {
        public static void Map(WebApplication app)
        {
            //get all products
            app.MapGet("/products", (BangazonBeDbContext db) =>
            {
                return db.Products
                    .Where(p => p.Quantity > 0)
                    .Select(p => new
                    {
                        p.Id,
                        p.Title,
                        p.ImageUrl,
                        p.Price,
                        Sold = p.OrderProducts.Count(op => op.PriceAtSale > 0),
                        p.Category,
                        Seller = new { p.Seller.Id, p.Seller.Username },
                    })
                    .OrderBy(p => p.Title)
                    .ToList();
            });

            app.MapGet("/products/top", (BangazonBeDbContext db) =>
            {
                return db.Products
                    .Where(p => p.Quantity > 0)
                    .Select(p => new
                    {
                        p.Id,
                        p.Title,
                        p.ImageUrl,
                        p.Price,
                        Sold = p.OrderProducts.Count(op => op.PriceAtSale > 0),
                        p.Category,
                        Seller = new { p.Seller.Id, p.Seller.Username },
                    })
                    .OrderByDescending(p => p.Sold)
                    .Take(20)
                    .ToList();
            });

            //Get single product
            app.MapGet("/products/{id}", (BangazonBeDbContext db, int id) =>
            {
                Product? product = db.Products
                    .Include(p => p.Category)
                    .Include(p => p.Seller)
                    .FirstOrDefault(p => p.Id == id);

                if (product == null)
                {
                    return Results.NotFound("Invalid Product Id");
                }

                return Results.Ok(new
                {
                    product.Id,
                    product.Title,
                    product.Description,
                    product.ImageUrl,
                    product.Quantity,
                    product.Category,
                    product.Price,
                    Seller = new { product.Seller.Id, product.Seller.Username },
                });
            });
        }
    }
}