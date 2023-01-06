using Microsoft.EntityFrameworkCore;
using RehberWeb.Models.Entities;

namespace RehberWeb.Models.Context
{
    public class RehberDbContext : DbContext
    {
        public RehberDbContext()
        {
        }

        public RehberDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Rehber> Rehbers { get; set; }
        public DbSet<IletisimBilgileri> IletisimBilgileris { get; set; }
        public DbSet<Rapor> Rapors { get; set; }
        public DbSet<RaporData> data { get; set; }

    }
}
