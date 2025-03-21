using Stock.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Stock.Interfaces
{
    public interface IMovimentacaoDomain
    {
        Task<Movimentacao> Create(Movimentacao item);
        Task<int> Delete(int id);
        Task<Movimentacao> GetById(int id);
        Task<IEnumerable<Movimentacao>> List();
        Task<int> Update(Movimentacao item);
    }
}