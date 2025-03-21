using Microsoft.EntityFrameworkCore;
using Stock.Model;

namespace Stock.Repository
{
    public class StockServerContext : DbContext
    {
        public StockServerContext(DbContextOptions<StockServerContext> options) : base(options)
        {
        }

        public DbSet<Produto> Produto { get; set; } = default!;
        public DbSet<Movimentacao> Movimentacao { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Produto
            modelBuilder.Entity<Produto>().Property(b => b.Nome).IsRequired();
            modelBuilder.Entity<Produto>().Property(b => b.Codigo).IsRequired();
            #endregion

            #region Produto
            modelBuilder.Entity<Movimentacao>().Property(b => b.Tipo).IsRequired();
            modelBuilder.Entity<Movimentacao>().Property(b => b.CriadoEm).IsRequired();
            modelBuilder.Entity<Movimentacao>().Property(b => b.Quantidade).IsRequired();
            #endregion

            #region Produto x Produto
            modelBuilder.Entity<Produto>()
                .HasMany(produto => produto.Movimentacoes)
                .WithOne(movimentacao => movimentacao.Produto)
                .HasForeignKey(movimentacao => movimentacao.ProdutoId)
                .HasPrincipalKey(produto => produto.Id);
            #endregion
        }
    }
}
