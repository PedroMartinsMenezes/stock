using Stock.Model.Dto;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Stock.Interfaces
{
    public interface IMovimentacaoDomain
    {
        Task<MovimentacaoResponse> Create(MovimentacaoRequest item);
        Task<RelatorioResponse> GetEstoque(DateTime dia, string codigoProduto);
        Task<int> Delete(int id);
        Task<MovimentacaoResponse> GetById(int id);
        Task<IEnumerable<MovimentacaoResponse>> List();
        Task<int> Update(MovimentacaoRequest item);
    }
}