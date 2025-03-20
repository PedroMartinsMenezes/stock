using Microsoft.EntityFrameworkCore;

namespace Stock.Server.Data
{
    public class StockServerContext : DbContext
    {
        public StockServerContext(DbContextOptions<StockServerContext> options)
            : base(options)
        {
        }

        public DbSet<MvcMovie.Models.Movie> Movie { get; set; } = default!;
    }
}
