using ProjetoWebApi.Models;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

List<Produto> listaDeProdutos = new()
{
    new Produto { Nome = "Notebook Gamer" },
    new Produto { Nome = "Mouse Sem Fio" },
    new Produto { Nome = "Teclado Mecânico" },
    new Produto { Nome = "Monitor 4K" },
    new Produto { Nome = "Headset Bluetooth" },
    new Produto { Nome = "Webcam HD" },
    new Produto { Nome = "Cadeira Ergonômica" },
    new Produto { Nome = "Suporte para Monitor" },
    new Produto { Nome = "Microfone Condensador" },
    new Produto { Nome = "SSD 1TB" }
};

// Endpoints - Funcionalidades aplicação
app.MapGet("/", () => "API de Produtos!");

// GET: /api/produto/listar
app.MapGet("/api/produto/listar", () =>
{
    return listaDeProdutos;
});

// POST: /api/produto/cadastrar
app.MapPost("/api/produto/cadastrar", (Produto produto) =>
{
    listaDeProdutos.Add(produto);
});

// Rodar aplicação
app.Run();