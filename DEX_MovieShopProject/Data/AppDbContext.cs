using DEX_MovieShopProject.Models;
using Microsoft.EntityFrameworkCore;

namespace DEX_MovieShopProject.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Movie> Movies { get; set; }

    }
}
