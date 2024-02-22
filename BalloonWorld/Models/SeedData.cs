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
                        Occasion = "Birthday Party",
                        Size="M",
                        Shape="Heart",
                        Price = 3.99M
                    },
                    new Balloon
                    {
                    Material="Latex",
                    Occasion="anniversary party ",
                    Size="L",
                    Shape="Circle",
                    Price=2.99M,
                },
                    new Balloon
                    {
                        Material = "Metalized Plastic",
                        Occasion = "Yearly Anniversaries",
                        Size = "Standard",
                        Shape = "Round",
                        Price = 6.55M,
                    },
                    new Balloon
                    {
                        Material = "Metalized Plastic",
                        Occasion = " Farewell Parties",
                        Size = "XL",
                        Shape = "Star",
                        Price = 5.55M,
                    },
                    new Balloon
                    {
                        Material = "Polychloroprene",
                        Occasion = " Baby Shower",
                        Size = "Small",
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
                    },
                    new Balloon
                    {
                        Material = "mylar",
                        Occasion = " Dance Party",
                        Size = "Standard",
                        Shape = "Round",
                        Price = 12.05M,
                    },
                    new Balloon
                    {
                        Material = "latex",
                        Occasion = " Farewell party",
                        Size = "Large",
                        Shape = "Heart",
                        Price = 10.5M,
                    },
                    new Balloon
                    {
                        Material = "nylon",
                        Occasion = " marriage ceremony",
                        Size = "Medium",
                        Shape = "Round",
                        Price = 12.55M,
                    },
                    new Balloon
                    {
                        Material = "Rubber",
                        Occasion = " valentines party",
                        Size = "Standard",
                        Shape = "Heart",
                        Price = 15.55M,
                    }


                );
                context.SaveChanges();
            }
        }
    }

}

