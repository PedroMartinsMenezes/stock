using Stock.Model.Entity;

namespace Stock.Model.Dto
{
    public class CreateMovimentacaoRequest
    {
        public string CodigoProduto { get; set; }
        public TipoMovimentacao TipoMovimentacao { get; set; }
        public int Quantidade { get; set; }
    }
}
