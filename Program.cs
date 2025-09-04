// ====================================================
// ARTONIUM API - SISTEMA DE PERSONAGENS TORMENTA 20
// ====================================================
// Configuração principal da aplicação

using Microsoft.EntityFrameworkCore;
using ArtoniumApi.Data;

var builder = WebApplication.CreateBuilder(args);

// ====================================================
// CONFIGURAÇÃO DOS SERVIÇOS
// ====================================================

// Controllers para APIs REST
builder.Services.AddControllers();

// Documentação automática
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() 
    { 
        Title = "Artonium API", 
        Version = "v1",
        Description = "Sistema de gerenciamento de personagens para Tormenta 20"
    });
});

// Configuração do banco PostgreSQL
builder.Services.AddDbContext<ArtoniumDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// ====================================================
// CONSTRUÇÃO DA APLICAÇÃO
// ====================================================
var app = builder.Build();

// ====================================================
// CRIAÇÃO AUTOMÁTICA DO BANCO (DESENVOLVIMENTO)
// ====================================================
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<ArtoniumDbContext>();
    context.Database.EnsureCreated(); // Cria o banco automaticamente
}

// ====================================================
// CONFIGURAÇÃO DO PIPELINE
// ====================================================

// Swagger em desenvolvimento
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Artonium API v1");
        c.RoutePrefix = "swagger";
    });
}

app.UseAuthorization();
app.MapControllers();

// Endpoint de saúde da aplicação
app.MapGet("/", () => "⚔️ Artonium API - Sistema de Personagens Tormenta 20")
   .WithName("HealthCheck")
   .WithOpenApi();

app.Run();
