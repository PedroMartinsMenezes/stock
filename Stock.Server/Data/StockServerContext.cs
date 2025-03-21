using Microsoft.EntityFrameworkCore;
using Stock.Server.Models;

namespace Stock.Server.Data
{
    public class StockServerContext : DbContext
    {
        public StockServerContext(DbContextOptions<StockServerContext> options) : base(options)
        {
        }

        public DbSet<Produto> Produto { get; set; } = default!;
        public DbSet<Movimentacao> Movimentacao { get; set; } = default!;
    }
}
