using System;

namespace ProjetoWebApi.Models;

public class Produto
{
    public long Id { get; set; } 
    public string? Nome { get; set; }
    public int Quantidade { get; set; }
    public double Preco { get; set; }
    public DateTime DataCadastro { get; set; } = DateTime.Now;
}
