using Microsoft.EntityFrameworkCore;
using Stock.Server.Data;

namespace Stock.Server.Models;

public static class SeedProduto
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new StockServerContext(serviceProvider.GetRequiredService<DbContextOptions<StockServerContext>>()))
        {
            if (context.Produto.Any())
            {
                return;
            }
            context.Produto.AddRange(
                Produto("Playstation 1", "PS1"),
                Produto("Playstation 2", "PS2"),
                Produto("Playstation 3", "PS3"),
                Produto("Playstation 4", "PS4"),
                Produto("Playstation 5", "PS5"),
                Produto("XBOX", "XBO"),
                Produto("XBOX 360", "XB360"),
                Produto("XBOX One", "XBONE"),
                Produto("XBOX Series S", "XBS"),
                Produto("XBOX Series X", "XBX")
            );
            context.SaveChanges();
        }
    }

    private static Produto Produto(string nome, string codigo)
    {
        return new Produto
        {
            Nome = nome,
            Codigo = codigo,
        };
    }
}