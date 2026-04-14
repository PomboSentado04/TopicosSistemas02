using System;

namespace ProjetoWebApi.Models;

public class Produto
{
    public string? Id { get; set; } = Guid.NewGuid().ToString();
    public string? Nome { get; set; }
    public double Preco { get; set; }
    public DateTime DataCadastro { get; set; } = DateTime.Now;
}
