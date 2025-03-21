using Stock.Model.Dto;
using Stock.Model.Entity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Stock.Interfaces
{
    public interface IMovimentacaoDomain
    {
        Task<Movimentacao> Create(CreateMovimentacaoRequest item);
        Task<RelatorioResponse> GetEstoque(DateTime dia, string codigoProduto);
        Task<int> Delete(int id);
        Task<Movimentacao> GetById(int id);
        Task<IEnumerable<Movimentacao>> List();
        Task<int> Update(Movimentacao item);
    }
}