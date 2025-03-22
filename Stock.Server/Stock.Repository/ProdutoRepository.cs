using Microsoft.EntityFrameworkCore;
using Stock.Interfaces;
using Stock.Model.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Stock.Repository
{
    internal class ProdutoRepository(StockServerContext context) : IProdutoRepository
    {
        private readonly StockServerContext _context = context;

        public async Task<Produto> Create(Produto item)
        {
            _context.Add(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<int> Delete(int id)
        {
            return await _context.Produto.Where(x => x.Id == id).ExecuteDeleteAsync();
        }

        public async Task<Produto> GetById(int id)
        {
            return await _context.Produto.FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<Produto> GetByCodigo(string codigo)
        {
            return await _context.Produto.Include(x => x.Movimentacoes).FirstOrDefaultAsync(m => m.Codigo == codigo);
        }

        public async Task<IEnumerable<Produto>> List()
        {
            return await _context.Produto.ToListAsync();
        }

        public async Task<IEnumerable<Produto>> ListMovimentacoes()
        {
            return await _context.Produto.Include(x => x.Movimentacoes).ToListAsync();
        }

        public async Task<int> Update(Produto item)
        {
            return await _context.Produto
            .Where(x => x.Id == item.Id)
            .ExecuteUpdateAsync(setters => setters
            .SetProperty(x => x.Nome, item.Nome)
            .SetProperty(x => x.Codigo, item.Codigo));
        }
    }
}
