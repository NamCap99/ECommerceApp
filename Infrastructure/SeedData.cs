using E_Commerce.Domain.Entities;
using E_Commerce.Shared.Helpers;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Infrastructure.Persistence
{
    public static class SeedData
    {
        public static void Initialize(ECommerceDbContext context)
        {
            // Ensure database is created
            context.Database.Migrate();

            try
            {
                // SEED CATEGORIES
                if (!context.Categories.Any())
                {
                    var clothing = new Category { Name = "Clothing" };
                    var electronics = new Category { Name = "Electronics" };

                    context.Categories.AddRange(clothing, electronics);
                    context.SaveChanges();

                    // SEED PRODUCTS
                    if (!context.Products.Any())
                    {
                        var products = new List<Product>
                        {
                            new Product
                            {
                                Name = "T-Shirt",
                                Price = 19.99m,
                                StockQuantity = 100,
                                Description = "100% cotton t-shirt",
                                SKU = "SKU001",
                                CategoryId = clothing.Id,
                                ImageUrl = "https://example.com/images/tshirt.jpg"
                            },
                            new Product
                            {
                                Name = "Jeans",
                                Price = 49.99m,
                                StockQuantity = 60,
                                Description = "Slim fit jeans",
                                SKU = "SKU002",
                                CategoryId = clothing.Id,
                                ImageUrl = "https://example.com/images/jeans.jpg"
                            },
                            new Product
                            {
                                Name = "Bluetooth Speaker",
                                Price = 79.99m,
                                StockQuantity = 25,
                                Description = "Wireless speaker with bass",
                                SKU = "SKU003",
                                CategoryId = electronics.Id,
                                ImageUrl = "https://example.com/images/speaker.jpg"
                            }
                        };

                        context.Products.AddRange(products);
                        context.SaveChanges();
                    }

                    // Seed Admin User
                    if (!context.Users.Any())
                    {
                        var hasher = new PasswordHasher<User>();

                        var adminUser = new User
                        {
                            FullName = "Admin",
                            Email = "admin@shop.com",
                            Role = "Admin",
                            CreatedAt = DateTime.UtcNow,
                            IsEmailConfirmed = true
                        };

                        adminUser.PasswordHash = hasher.HashPassword(adminUser, "admin123");

                        context.Users.Add(adminUser);
                        context.SaveChanges();
                    }
                }
            }
                
            catch (Exception ex)
            {
                Console.WriteLine("Seeding error: " + ex.Message);
                throw;
            }
        }

    }
}
