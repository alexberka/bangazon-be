using Microsoft.EntityFrameworkCore;
using bangazon_be.Models;
using bangazon_be.Dtos;
using System.Runtime.CompilerServices;

namespace bangazon_be.Apis
{
    public class UsersApi
    {
        public static void Map(WebApplication app)
        {
            //
            app.MapPost("/checkuser", (BangazonBeDbContext db, User userCheck) =>
            {
                User? user = db.Users.FirstOrDefault(u => u.Uid == userCheck.Uid);

                if (user == null)
                {
                    return Results.NotFound("User is not registered");
                }

                return Results.Ok(user);
            });

            app.MapPost("/register", (BangazonBeDbContext db, NewUserDto userRegister) =>
            {
                User newUser = new User
                {
                    FirstName = userRegister.FirstName,
                    LastName = userRegister.LastName,
                    Username = userRegister.Username,
                    Address = userRegister.Address,
                    Email = userRegister.Email,
                    Uid = userRegister.Uid
                };

                db.Users.Add(newUser);
                db.SaveChanges();

                return Results.Created($"/users/{newUser.Id}", newUser);
            });


            //Get sellers
            //Includes three most sold products
            app.MapGet("/sellers", (BangazonBeDbContext db) =>
            {
                return db.Users
                    .Where(u => u.Products.Count() > 0)
                    .Select(u => new
                    {
                        u.Id,
                        u.FirstName,
                        u.LastName,
                        u.Username,
                        Products = u.Products
                            .Select(p => new
                            {
                                p.Id,
                                p.Title,
                                p.ImageUrl,
                                p.Price,
                                Sold = p.OrderProducts.Count(op => op.PriceAtSale > 0),
                                InCarts = p.OrderProducts.Count(op => op.PriceAtSale == 0),
                                p.Category
                            })
                            .OrderByDescending(p => p.Sold + p.InCarts)
                            .ThenByDescending(p => p.Sold)
                            .Take(3)
                            .ToList(),
                        ItemsSold = u.Products
                            .Select(p => p.OrderProducts.Count(op => op.PriceAtSale > 0))
                            .Sum(),

                    })
                    .ToList();
            });

            //Get single seller
            //Includes all products
            app.MapGet("/sellers/{id}", (BangazonBeDbContext db, int id) =>
            {
                User? user = db.Users
                    .Include(u => u.Products)
                    .ThenInclude(p => p.OrderProducts)
                    .Include(u => u.Products)
                    .ThenInclude(p => p.Category)
                    .FirstOrDefault(u => u.Id == id);

                if (user == null)
                {
                    return Results.NotFound("Invalid User Id");
                }

                if (user.Products.Count() == 0)
                {
                    return Results.BadRequest("User does not have a storefront");
                }

                var seller = new
                {
                    user.Id,
                    user.FirstName,
                    user.LastName,
                    user.Username,
                    Products = user.Products
                            .Select(p => new
                            {
                                p.Id,
                                p.Title,
                                p.ImageUrl,
                                p.Price,
                                Sold = p.OrderProducts.Count(op => op.PriceAtSale > 0),
                                p.Category
                            })
                            .OrderBy(p => p.Title)
                            .ToList(),
                    ItemsSold = user.Products
                            .Select(p => p.OrderProducts.Count(op => op.PriceAtSale > 0))
                            .Sum(),
                };

                return Results.Ok(seller);
            });

            //Get profile of current user
            app.MapGet("/user/{uid}", (BangazonBeDbContext db, string uid) =>
            {
                User? user = db.Users.FirstOrDefault(u => u.Uid == uid);

                if (user == null)
                {
                    Results.NotFound("Profile not found");
                }

                return user;

            });
        }
    }
}