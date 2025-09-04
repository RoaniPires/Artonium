// ====================================================
// PROGRAMA PRINCIPAL DA API - HELLO WORLD BÁSICO
// ====================================================
// Este é o ponto de entrada da nossa aplicação .NET 8
// Aqui configuramos todos os serviços e o pipeline de requisições

// Criamos o builder que vai configurar nossa aplicação
var builder = WebApplication.CreateBuilder(args);

// ====================================================
// CONFIGURAÇÃO DOS SERVIÇOS (Dependency Injection)
// ====================================================
// Aqui registramos todos os serviços que nossa aplicação vai usar

// 1. Adiciona suporte para Controllers (endpoints da API)
builder.Services.AddControllers();

// 2. Adiciona serviços para documentação da API
builder.Services.AddEndpointsApiExplorer(); // Explora os endpoints automaticamente
builder.Services.AddSwaggerGen();           // Gera a documentação Swagger/OpenAPI

// ====================================================
// CONSTRUÇÃO DA APLICAÇÃO
// ====================================================
// Agora pegamos tudo que configuramos e criamos a aplicação
var app = builder.Build();

// ====================================================
// CONFIGURAÇÃO DO PIPELINE DE REQUISIÇÕES
// ====================================================
// Define como as requisições HTTP serão processadas (ordem importa!)

// 1. Habilita a documentação Swagger (interface web para testar a API)
app.UseSwagger();     // Gera o JSON da documentação
app.UseSwaggerUI();   // Cria a interface web em /swagger

// 2. Adiciona autorização (mesmo sem usar ainda, é boa prática)
app.UseAuthorization();

// 3. Mapeia os controllers para responder às rotas
app.MapControllers();

// ====================================================
// ENDPOINT BÁSICO HELLO WORLD
// ====================================================
// Cria um endpoint simples para testar se a API está funcionando
app.MapGet("/", () => "🚀 Artonium API está funcionando! Acesse /swagger para ver a documentação.")
   .WithName("HelloWorld")                    // Nome interno do endpoint
   .WithOpenApi();                            // Inclui na documentação Swagger

// ====================================================
// INICIA A APLICAÇÃO
// ====================================================
// Inicia o servidor web e fica escutando requisições
app.Run();
