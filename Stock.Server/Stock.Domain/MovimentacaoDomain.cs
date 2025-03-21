using Stock.Interfaces;
using Stock.Model.Dto;
using Stock.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Stock.Domain
{
    internal class MovimentacaoDomain : IMovimentacaoDomain
    {
        private readonly IMovimentacaoRepository _repository;
        private readonly IProdutoRepository _produtoRepository;

        public MovimentacaoDomain(IMovimentacaoRepository repository, IProdutoRepository produtoRepository)
        {
            _repository = repository;
            _produtoRepository = produtoRepository;
        }

        public async Task<Movimentacao> Create(MovimentacaoRequest item)
        {
            if ((int)item.TipoMovimentacao != (int)TipoMovimentacao.Entrada && (int)item.TipoMovimentacao != (int)TipoMovimentacao.Saida)
            {
                throw new InvalidOperationException("Tipo de movimentação inválido.");
            }
            Produto produto = await _produtoRepository.GetByCodigo(item.CodigoProduto);
            if (produto is null)
            {
                throw new InvalidOperationException("Código de produto inválido.");
            }
            int quantidade = item.TipoMovimentacao == TipoMovimentacao.Entrada ? item.Quantidade : -item.Quantidade;
            if (produto.Movimentacoes.Sum(x => x.Quantidade) + quantidade < 0)
            {
                throw new InvalidOperationException("Quantidade informada gerará estoque negativo.");
            }
            Movimentacao movimentacao = new Movimentacao
            {
                ProdutoId = produto.Id,
                Quantidade = item.Quantidade,
                Tipo = item.TipoMovimentacao,
                CriadoEm = DateTime.UtcNow
            };
            return await _repository.Create(movimentacao);
        }

        public async Task<int> Delete(int id)
        {
            return await _repository.Delete(id);
        }

        public async Task<Movimentacao> GetById(int id)
        {
            return await _repository.GetById(id);
        }

        public async Task<IEnumerable<Movimentacao>> List()
        {
            return await _repository.List();
        }

        public async Task<int> Update(Movimentacao item)
        {
            return await _repository.Update(item);
        }
    }
}
