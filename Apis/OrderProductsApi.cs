using bangazon_be.Models;
using Microsoft.EntityFrameworkCore;

namespace bangazon_be.Apis
{
    public class OrderProductsApi
    {
        public static void Map(WebApplication app)
        {
            app.MapPost("/cart/{userId}/add/{productId}", (BangazonBeDbContext db, int userId, int productId) =>
            {
                if (!db.Users.Any(u => u.Id == userId) || !db.Products.Any(p => p.Id == productId))
                {
                    return Results.NotFound();
                }

                int? orderId = db.Orders.FirstOrDefault(o => o.CustomerId == userId && o.CompletionDate == null)?.Id;

                if (orderId == null)
                {
                    Order newCart = new Order { CustomerId = userId };
                    db.Orders.Add(newCart);
                    db.SaveChanges();
                    orderId = newCart.Id;
                }

                OrderProduct newOrderProduct = new OrderProduct
                {
                    OrderId = (int) orderId,
                    ProductId = productId
                };

                db.OrderProducts.Add(newOrderProduct);
                db.SaveChanges();
                return Results.Created($"/order-products/{newOrderProduct.Id}", newOrderProduct);
            });

            //Remove product from user's open order
            app.MapDelete("/cart/{userId}/remove/{orderProductId}", (BangazonBeDbContext db, int userId, int orderProductId) =>
            {
                Order? cart = db.Orders
                    .Include(o => o.OrderProducts)
                    .FirstOrDefault(o => o.CustomerId == userId && o.CompletionDate == null);

                OrderProduct? deleteOrderProduct = cart?.OrderProducts.FirstOrDefault(op => op.Id == orderProductId);

                if (deleteOrderProduct == null)
                {
                    return Results.NotFound();
                }

                db.OrderProducts.Remove(deleteOrderProduct);
                db.SaveChanges();
                return Results.Ok();
            });
        }
    }
}