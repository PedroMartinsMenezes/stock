using Stock.Model.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Stock.Interfaces
{
    public interface IProdutoDomain
    {
        Task<ProdutoResponse> Create(ProdutoRequest item);
        Task<int> Delete(int id);
        Task<ProdutoResponse> GetById(int id);
        Task<IEnumerable<ProdutoResponse>> List();
        Task<int> Update(ProdutoRequest item);
    }
}