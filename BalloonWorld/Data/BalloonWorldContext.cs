using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BalloonWorld.Models;

namespace BalloonWorld.Data
{
    public class BalloonWorldContext : DbContext
    {
        public BalloonWorldContext (DbContextOptions<BalloonWorldContext> options)
            : base(options)
        {
        }

        public DbSet<BalloonWorld.Models.Balloon> Balloon { get; set; } = default!;
    }
}
