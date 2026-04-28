using System;
using Microsoft.EntityFrameworkCore;
using ProjetoWebApi.Models;

namespace ProjetoWebApi.Data;

/// <summary>
/// Classe que representa o banco de dados
/// </summary>
public class AppDataContext : DbContext
{
    public DbSet<Produto> Produtos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=Banco.db");
    }
}
