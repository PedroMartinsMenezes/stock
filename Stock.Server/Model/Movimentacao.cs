namespace MvcMovie.Models;

public class Movimentacao
{
    public int Id { get; set; }

    public Produto? Produto { get; set; }

    public string? Tipo { get; set; }
    public DateTime? CriadoEm { get; set; }
    public int Quantidade { get; set; }
}