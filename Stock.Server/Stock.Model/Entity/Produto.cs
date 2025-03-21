using System.Collections.Generic;

namespace Stock.Model.Entity
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Codigo { get; set; }
        public ICollection<Movimentacao> Movimentacoes { get; }
    }
}