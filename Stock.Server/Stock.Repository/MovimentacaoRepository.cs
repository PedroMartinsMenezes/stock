using Microsoft.EntityFrameworkCore;
using Stock.Interfaces;
using Stock.Model.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Stock.Repository
{
    internal class MovimentacaoRepository(StockServerContext context) : IMovimentacaoRepository
    {
        private readonly StockServerContext _context = context;

        public async Task<Movimentacao> Create(Movimentacao item)
        {
            _context.Add(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<int> Delete(int id)
        {
            return await _context.Movimentacao.Where(x => x.Id == id).ExecuteDeleteAsync();
        }

        public async Task<Movimentacao> GetById(int id)
        {
            return await _context.Movimentacao.FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<IEnumerable<Movimentacao>> List()
        {
            return await _context.Movimentacao.ToListAsync();
        }

        public async Task<int> Update(Movimentacao item)
        {
            return await _context.Movimentacao
            .Where(x => x.Id == item.Id)
            .ExecuteUpdateAsync(setters => setters
            .SetProperty(x => x.ProdutoId, item.ProdutoId)
            .SetProperty(x => x.Tipo, item.Tipo)
            .SetProperty(x => x.CriadoEm, item.CriadoEm)
            .SetProperty(x => x.Quantidade, item.Quantidade));
        }
    }
}
