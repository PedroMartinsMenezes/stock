namespace Stock.Model.Dto
{
    public class RelatorioResponse
    {
        public string NomeProduto { get; set; }
        public string CodigoProduto { get; set; }
        public int Entradas { get; set; }
        public int Saidas { get; set; }
        public int Saldo => Entradas - Saidas;
    }
}
