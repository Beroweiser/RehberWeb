using Microsoft.EntityFrameworkCore;

namespace RehberWeb.Models.Context
{
    public class RehberDbContext : DbContext
    {
        public RehberDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
