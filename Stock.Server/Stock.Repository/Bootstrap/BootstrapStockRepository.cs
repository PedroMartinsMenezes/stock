using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Stock.Interfaces;
using System;

namespace Stock.Repository
{
    public static class BootstrapStockRepository
    {
        public static void RegisterStockRepository(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<StockServerContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("StockServerContext") ?? throw new InvalidOperationException("Connection string 'StockServerContext' not found.")));

            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<IMovimentacaoRepository, MovimentacaoRepository>();
        }
    }
}
