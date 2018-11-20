using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace SportsStore.Models
{
    public static class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            var context = app.ApplicationServices.GetRequiredService<ApplicationDbContext>();
            context.Database.Migrate();
            if (!context.Products.Any())
            {
                context.Products.AddRange(
                    new Product
                    {
                        Name = "Kayak", Description = "A boat for one person",
                        Category = "Watersports", Price = 275
                    },
                    new Product
                    {
                        Name = "LIfejacket",
                        Description = "Protective and fasionable",
                        Category = "Watersports",
                        Price = 48.50m
                    },
                    new Product
                    {
                        Name = "Soccer Ball",
                        Description = "FIFA-Approved size and weight",
                        Category = "Soccer", Price = 19.50m
                    },
                    new Product
                    {
                        Name = "Corner Flags",
                        Description = "Give your playing feild a professional touch",
                        Category = "Soccer", Price = 34.95m
                    },
                    new Product
                    {
                        Name = "Stadium",
                        Description = "Flat-packed 35,000-seat stadium",
                        Category = "Soccer", Price = 79500
                    },
                    new Product
                    {
                        Name = "Thinking Cap",
                        Category = "Chess",
                        Description = "Improve brain efficiency by 75%", Price = 16
                    },
                    new Product
                    {
                        Name = "Unsteady Chair",
                        Description = "Secretly give your opponent an unfair advantage",
                        Category = "Chess",
                        Price = 29.95m
                    },
                    new Product
                    {
                        Name = "Human Chess Board",
                        Description = "Fun for the whole family",
                        Category = "Chess", Price = 75
                    },
                    new Product
                    {
                        Name = "Bling-Bling King",
                        Description = "Gold-plated, diamon-studded King",
                        Category = "Chess", Price = 1200
                    }
                );
                context.SaveChanges();
            }
        }
    }
}