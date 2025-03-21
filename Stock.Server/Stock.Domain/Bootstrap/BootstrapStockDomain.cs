using Microsoft.Extensions.DependencyInjection;
using Stock.Interfaces;

namespace Stock.Domain
{
    public static class BootstrapStockDomain
    {
        public static void RegisterStockDomain(this IServiceCollection services)
        {
            services.AddScoped<IProdutoDomain, ProdutoDomain>();
            services.AddScoped<IMovimentacaoDomain, MovimentacaoDomain>();
        }
    }
}
