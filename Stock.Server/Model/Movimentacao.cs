using System;

namespace Stock.Server.Models
{
    public class Movimentacao
    {
        public int Id { get; set; }

        public Produto Produto { get; set; }
        public int ProdutoId { get; set; }

        public TipoMovimentacao Tipo { get; set; }

        public DateTime CriadoEm { get; set; }

        public int Quantidade { get; set; }
    }

    public enum TipoMovimentacao
    {
        Entrada = 1,
        Saida = 2
    }
}