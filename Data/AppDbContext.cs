using CozyComfort.API.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace CozyComfort.API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Seller> Sellers { get; set; }

        public DbSet<Distributor> Distributors { get; set; }

        public DbSet<Blanket> Blankets { get; set; }

        public DbSet<Order> Orders { get; set; }
    }
}