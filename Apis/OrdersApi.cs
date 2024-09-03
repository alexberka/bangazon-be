using bangazon_be.Models;
using Microsoft.EntityFrameworkCore;

namespace bangazon_be.Apis
{
    public class OrdersApi
    {
        public static void Map(WebApplication app)
        {
            app.MapGet("/user/{id}/cart", (BangazonBeDbContext db, int id) =>
            {
                return db.Orders
                    .Where(o => o.CustomerId == id && o.CompletionDate == null)
                    .Select(o => new
                    {
                        o.Id,
                        Products = o.OrderProducts.Select(op => new
                        {
                            Id = op.ProductId,
                            OrderProductId = op.Id,
                            op.Product.Title,
                            op.Product.ImageUrl,
                            op.Product.Price,
                            Seller = new { op.Product.Seller.Id, op.Product.Seller.Username }
                        }),
                        CurrentCost = o.Products.Sum(p => p.Price)
                    })
                    .FirstOrDefault();
            });

            app.MapGet("/user/{id}/orders", (BangazonBeDbContext db, int id) =>
            {
                return db.Orders
                    .Where(o => o.CustomerId == id && o.CompletionDate != null)
                    .Select(o => new
                    {
                        o.Id,
                        o.CompletionDate,
                        o.TotalCost,
                        o.PaymentType,
                        TotalItems = o.OrderProducts.Count()
                    })
                    .OrderByDescending(o => o.CompletionDate)
                    .ToList();
            });

            app.MapGet("/user/orders/{orderId}", (BangazonBeDbContext db, int orderId) =>
            {
                return db.Orders
                    .Where(o => o.Id == orderId && o.CompletionDate != null)
                    .Select(o => new
                    {
                        o.Id,
                        o.CompletionDate,
                        o.TotalCost,
                        o.PaymentType,
                        Products = o.OrderProducts.Select(op => new
                        {
                            Id = op.ProductId,
                            Price = op.PriceAtSale,
                            op.Product.Title,
                            op.Product.ImageUrl,
                            Seller = new { op.Product.Seller.Id, op.Product.Seller.Username }
                        }),
                        TotalItems = o.OrderProducts.Count()
                    })
                    .OrderByDescending(o => o.CompletionDate)
                    .FirstOrDefault();
            });

            app.MapPut("/checkout/{orderId}", (BangazonBeDbContext db, int orderId, string paymentType) =>
            {
                Order? checkoutOrder = db.Orders
                    .Include(o => o.OrderProducts)
                    .ThenInclude(op => op.Product)
                    .FirstOrDefault(o => o.Id == orderId);

                if (checkoutOrder == null)
                {
                    return Results.NotFound("Invalid Order Id");
                }
                else if (checkoutOrder.CompletionDate != null)
                {
                    return Results.BadRequest("Order has already been completed");
                }

                checkoutOrder.CompletionDate = DateTime.Now;
                checkoutOrder.TotalCost = checkoutOrder.OrderProducts.Sum(op => op.Product.Price);
                checkoutOrder.PaymentType = paymentType;

                foreach (OrderProduct op in checkoutOrder.OrderProducts)
                {
                    op.PriceAtSale = op.Product.Price;
                }

                db.SaveChanges();
                return Results.Ok("Order completed");
            });
        }
    }
}