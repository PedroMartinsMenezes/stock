using Microsoft.EntityFrameworkCore;
using MvcMovie.Models;

namespace Stock.Server.Data
{
    public class StockServerContext : DbContext
    {
        public StockServerContext(DbContextOptions<StockServerContext> options) : base(options)
        {
        }

        public DbSet<Movie> Movie { get; set; } = default!;
        public DbSet<Produto> Produto { get; set; } = default!;
    }
}
