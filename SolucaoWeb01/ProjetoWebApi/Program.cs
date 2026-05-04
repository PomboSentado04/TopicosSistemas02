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

// GET: /api/produto/buscar/{id}
app.MapGet("/api/produto/buscar/{id}", ([FromRoute] long id, [FromServices] AppDataContext ctx) =>
{
    foreach (Produto produto in ctx.Produtos.ToList())
    {
        if (produto.Id == id)
            return Results.Ok(produto);
    }
    return Results.NotFound("Produto não encontrado.");
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

// PUT: /api/produto/editar/{id}
app.MapPut("/api/produto/editar/{id}", ([FromRoute] long id, [FromBody] Produto produtoEditado, [FromServices] AppDataContext ctx) =>
{
    var produto = ctx.Produtos.FirstOrDefault(p => p.Id == id);

    if (produto == null)
    {
        return Results.NotFound("Produto não encontrado.");
    }

    foreach (Produto produtoLista in ctx.Produtos.ToList().Where(p => p.Id != id))
    {
        if (produtoLista.Nome == produtoEditado.Nome)
            return Results.Conflict("Não é possível mudar o nome do produto para o de um já existente.");
    }

    produto.Nome = produtoEditado.Nome;
    produto.Quantidade = produtoEditado.Quantidade;
    produto.Preco = produtoEditado.Preco;
    ctx.SaveChanges();

    return Results.Ok(produto);
});

// DELETE: /api/produto/buscar/{id}
app.MapDelete("/api/produto/deletar/{id}", ([FromRoute] long id, [FromServices] AppDataContext ctx) =>
{
    var produto = ctx.Produtos.FirstOrDefault(p => p.Id == id);

    if (produto == null)
    {
        return Results.NotFound("Produto não encontrado.");
    }

    ctx.Remove(produto);
    ctx.SaveChanges();

    return Results.NoContent();
});

// Rodar aplicação
app.Run();