using Microsoft.AspNetCore.Mvc;
using ProjetoWebApi.Data;
using ProjetoWebApi.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppDataContext>();
var app = builder.Build();

List<Produto> listaDeProdutos = new List<Produto>();

// Endpoints - Funcionalidades aplicação
app.MapGet("/", () => "API de Produtos!");

// GET: /api/produto/listar
app.MapGet("/api/produto/listar", ([FromServices] AppDataContext ctx) =>
{
    if (ctx.Produtos.Any())
        return Results.Ok(ctx.Produtos.ToList());
    return Results.NotFound("Lista de produtos vazia!");
});

// POST: /api/produto/cadastrar
app.MapPost("/api/produto/cadastrar", ([FromBody] Produto produto, [FromServices] AppDataContext ctx) =>
{
    foreach (Produto produtoLista in ctx.Produtos.ToList())
    {
        if (produtoLista.Nome == produto.Nome)
            return Results.Conflict("Produto já existente.");
    }
    ctx.Produtos.Add(produto);
    ctx.SaveChanges();
    return Results.Created("", produto);
});

// GET: /api/produto/buscar/{id}
app.MapGet("/api/produto/buscar/{id}", ([FromRoute] long id) =>
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