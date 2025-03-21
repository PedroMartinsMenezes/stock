using Stock.Model.Entity;
using System;

namespace Stock.Model.Dto
{
    public class MovimentacaoCreateRequest
    {
        public TipoMovimentacao Tipo { get; set; }
        public int Quantidade { get; set; }
        public string CodigoProduto { get; set; }

        public Movimentacao ToEntity()
        {
            return new Movimentacao { Tipo = Tipo, Quantidade = Quantidade };
        }
    }

    public class MovimentacaoUpdateRequest
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
        public MovimentacaoResponse(Movimentacao other)
        {
            (Id, ProdutoId, Tipo, CriadoEm, Quantidade) = (other.Id, other.ProdutoId, other.Tipo, other.CriadoEm, other.Quantidade);
        }

        public int Id { get; set; }
        public int ProdutoId { get; set; }
        public TipoMovimentacao Tipo { get; set; }
        public DateTime CriadoEm { get; set; }
        public int Quantidade { get; set; }
    }
}
