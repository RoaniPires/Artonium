// ====================================================
// ARTONIUM API - SISTEMA DE PERSONAGENS TORMENTA 20
// ====================================================
// Configuração principal da aplicação

using MongoDB.Driver;

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

// Configuração do banco MongoDB
builder.Services.AddSingleton<IMongoClient>(sp =>
    new MongoClient(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddSingleton<ArtoniumApi.Services.PersonagemService>();

// ====================================================
// CONSTRUÇÃO DA APLICAÇÃO
// ====================================================
var app = builder.Build();


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
