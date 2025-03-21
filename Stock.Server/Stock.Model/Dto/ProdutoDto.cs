using Stock.Model.Entity;

namespace Stock.Model.Dto
{
    public class ProdutoRequest
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Codigo { get; set; }

        public Produto ToEntity()
        {
            return new Produto { Id = Id, Nome = Nome, Codigo = Codigo };
        }
    }

    public class ProdutoResponse
    {
        public ProdutoResponse(Produto other)
        {

            (Id, Nome, Codigo) = (other.Id, other.Nome, other.Codigo);
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Codigo { get; set; }
    }
}
