using Stock.Model.Entity;
using System;

namespace Stock.Model.Dto
{
    public class MovimentacaoRequest
    {
        public int Id { get; set; }
        public int ProdutoId { get; set; }
        public TipoMovimentacao Tipo { get; set; }
        public DateTime CriadoEm { get; set; }
        public int Quantidade { get; set; }
        public string CodigoProduto { get; set; }

        public Movimentacao ToEntity()
        {
            return new Movimentacao { Id = Id, ProdutoId = ProdutoId, Tipo = Tipo, CriadoEm = CriadoEm, Quantidade = Quantidade };
        }
    }

    public class MovimentacaoResponse
    {
        public MovimentacaoResponse(Movimentacao movimentacao)
        {

            Id = movimentacao.Id;
            Quantidade = movimentacao.Quantidade;
            CriadoEm = movimentacao.CriadoEm;
            Tipo = movimentacao.Tipo;
        }

        public int Id { get; set; }
        public int ProdutoId { get; set; }
        public TipoMovimentacao Tipo { get; set; }
        public DateTime CriadoEm { get; set; }
        public int Quantidade { get; set; }
    }
}
