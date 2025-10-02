using Microsoft.EntityFrameworkCore;
using ArtoniumApi.Data;
using ArtoniumApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Configuração dos serviços
builder.Services.AddControllers();
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

// PostgreSQL + Entity Framework
builder.Services.AddDbContext<ArtoniumContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Serviços da aplicação
builder.Services.AddScoped<IPersonagemService, PersonagemService>();

var app = builder.Build();

// Criação automática do banco
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<ArtoniumContext>();
    context.Database.EnsureCreated();
}

// Pipeline de requisições
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Artonium API v1");
    c.RoutePrefix = "swagger";
    c.DocumentTitle = "Artonium API - Tormenta 20";
});

app.UseAuthorization();
app.MapControllers();

// Health check
app.MapGet("/", () => "⚔️ Artonium API - Sistema de Personagens Tormenta 20")
   .WithName("HealthCheck")
   .WithOpenApi();

app.Run();
