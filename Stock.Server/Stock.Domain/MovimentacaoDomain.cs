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

        public async Task<MovimentacaoResponse> Create(MovimentacaoCreateRequest item)
        {
            Produto produto = await _produtoRepository.GetByCodigo(item.CodigoProduto);
            if (produto is null)
            {
                throw new InvalidOperationException("Código de produto inválido.");
            }
            if ((int)item.Tipo != (int)TipoMovimentacao.Entrada && (int)item.Tipo != (int)TipoMovimentacao.Saida)
            {
                throw new InvalidOperationException("Tipo de movimentação inválido.");
            }
            if (item.Quantidade <= 0)
            {
                throw new InvalidOperationException("Quantidade deve ser positiva");
            }
            int quantidade = item.Tipo == TipoMovimentacao.Entrada ? item.Quantidade : -item.Quantidade;
            int quantidadeEstoque = (produto.Movimentacoes ?? []).Sum(x => x.Quantidade * (x.Tipo == TipoMovimentacao.Entrada ? 1 : -1));
            if (quantidadeEstoque + quantidade < 0)
            {
                throw new InvalidOperationException("Quantidade informada gerará estoque negativo.");
            }
            Movimentacao movimentacao = new Movimentacao
            {
                Produto = produto,
                ProdutoId = produto.Id,
                Quantidade = item.Quantidade,
                Tipo = item.Tipo,
                CriadoEm = DateTime.UtcNow
            };
            await _repository.Create(movimentacao);
            return new MovimentacaoResponse(movimentacao);
        }

        public async Task<IEnumerable<RelatorioResponse>> GetEstoque(DateTime dia, string codigoProduto)
        {
            dia = dia == default ? DateTime.UtcNow.Date : dia;

            Produto produto = await _produtoRepository.GetByCodigo(codigoProduto);
            if (codigoProduto is not null && produto is null)
            {
                throw new InvalidOperationException("Código de produto inválido.");
            }

            var list = produto is { } ? [produto] : await _produtoRepository.ListMovimentacoes();

            return list.Select(produto => new RelatorioResponse
            {
                NomeProduto = produto.Nome,
                CodigoProduto = produto.Codigo,
                Entradas = (produto.Movimentacoes ?? []).Where(x => x.Tipo == TipoMovimentacao.Entrada && x.CriadoEm.Date == dia.Date).Sum(x => x.Quantidade),
                Saidas = (produto.Movimentacoes ?? []).Where(x => x.Tipo == TipoMovimentacao.Saida && x.CriadoEm.Date == dia.Date).Sum(x => x.Quantidade)
            });
        }

        public async Task<int> Delete(int id)
        {
            return await _repository.Delete(id);
        }

        public async Task<MovimentacaoResponse> GetById(int id)
        {
            return new MovimentacaoResponse(await _repository.GetById(id));
        }

        public async Task<IEnumerable<MovimentacaoResponse>> List()
        {
            return (await _repository.List()).Select(x => new MovimentacaoResponse(x));
        }

        public async Task<int> Update(MovimentacaoUpdateRequest item)
        {
            return await _repository.Update(item.ToEntity());
        }
    }
}
