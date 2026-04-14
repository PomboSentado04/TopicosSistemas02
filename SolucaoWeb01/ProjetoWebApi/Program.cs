using Microsoft.AspNetCore.Mvc;
using ProjetoWebApi.Models;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

List<Produto> listaDeProdutos = new List<Produto>();

// Endpoints - Funcionalidades aplicação
app.MapGet("/", () => "API de Produtos!");

// GET: /api/produto/listar
app.MapGet("/api/produto/listar", () =>
{
    if (listaDeProdutos.Any())
        return Results.Ok(listaDeProdutos);
    return Results.NotFound("Lista de produtos vazia!");
});

// POST: /api/produto/cadastrar
app.MapPost("/api/produto/cadastrar", ([FromBody] Produto produto) =>
{
    foreach (Produto produtoLista in listaDeProdutos)
    {
        if (produtoLista.Nome == produto.Nome)
            return Results.Conflict("Produto já existente.");
    }
    listaDeProdutos.Add(produto);
    return Results.Created("", produto);
});

// GET: /api/produto/buscar/{id}
app.MapGet("/api/produto/buscar/{id}", ([FromRoute] string id) =>
{
    foreach (Produto produtoLista in listaDeProdutos)
    {
        if (produtoLista.Id == id)
            return Results.Ok(produtoLista);
    }
    return Results.NotFound("Produto não encontrado.");
});

// Rodar aplicação
app.Run();