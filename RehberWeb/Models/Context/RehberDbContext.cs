using Microsoft.EntityFrameworkCore;
using RehberWeb.Models.Entities;

namespace RehberWeb.Models.Context
{
    public class RehberDbContext : DbContext
    {
        public RehberDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Rehber> Rehbers { get; set; }
        public DbSet<IletisimBilgileri> IletisimBilgileris { get; set; }

    }
}
