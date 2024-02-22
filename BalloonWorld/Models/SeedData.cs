using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using BalloonWorld.Data;
using System;
using System.Linq;
namespace BalloonWorld.Models
{
    public class SeedData
    {
        
    public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new BalloonWorldContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<BalloonWorldContext>>()))
            {
                // Look for any balloon.
                if (context.Balloon.Any())
                {
                    return;   // DB has been seeded
                }
                context.Balloon.AddRange(
                    new Balloon
                    {
                        Material = "Latex",
                        Occasion = "Party",
                        Size="M",
                        Shape="Heart",
                        Price = 3.99M
                    },
                    new Balloon
                    {
                    Material="Latex",
                    Occasion="Birthday",
                    Size="L",
                    Shape="Circle",
                    Price=2.99M,
                },
                    new Balloon
                    {
                        Material = "Metalized Plastic",
                        Occasion = "Yearly Anniversaries",
                        Size = "Standard",
                        Shape = "Star",
                        Price = 6.55M,
                    },
                    new Balloon
                    {
                        Material = "Metalized Plastic",
                        Occasion = " Farewell Parties",
                        Size = "Standard",
                        Shape = "Star",
                        Price = 5.55M,
                    },
                    new Balloon
                    {
                        Material = "Polychloroprene",
                        Occasion = " Gym's",
                        Size = "Standard",
                        Shape = "Round",
                        Price = 15.55M,
                    },
                    new Balloon
                    {
                        Material = "Rubber",
                        Occasion = "Water Balloon FIghts",
                        Size = "XS",
                        Shape = "Pear",
                        Price = 9.55M,
                    }
                  
                );
                context.SaveChanges();
            }
        }
    }

}

