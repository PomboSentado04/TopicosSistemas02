var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// Endpoints - Funcionalidades aplicação
app.MapGet("/", () => "API de Produtos!");
app.MapGet("/funcionalidade", () => "API de Produtos DOS!");
app.MapPost("/funcionalidade", () => "API de Produtos POST!");

// Rodar aplicação
app.Run();