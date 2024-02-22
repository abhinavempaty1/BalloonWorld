using System.ComponentModel.DataAnnotations;

namespace BalloonWorld.Models
{
    public class Balloon
    {
        public int Id { get; set; }
        public string? Material { get; set; }
        public string? Occasion { get; set; }
        public string? Size { get; set; }
        public string? Shape { get; set; }
        public decimal Price { get; set; }

        internal static Task<string?> ToListAsync()
        {
            throw new NotImplementedException();
        }
    }
}
