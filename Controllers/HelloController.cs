// ====================================================
// CONTROLLER DE APRENDIZADO - HELLO WORLD
// ====================================================
// Este arquivo define nossos endpoints (rotas) da API
// Um Controller agrupa endpoints relacionados

using Microsoft.AspNetCore.Mvc;

// Define o namespace (organização do código)
namespace ArtoniumApi.Controllers;

// ====================================================
// ATRIBUTOS DO CONTROLLER
// ====================================================
[ApiController]              // Indica que esta classe é um controller de API
[Route("api/[controller]")]  // Define a rota base: /api/hello (nome da classe sem "Controller")
public class HelloController : ControllerBase  // Herda funcionalidades básicas de API
{
    // ====================================================
    // ENDPOINT 1: GET - Buscar uma saudação
    // ====================================================
    // Responde a: GET /api/hello
    [HttpGet]  // Define que este método responde a requisições GET
    public ActionResult<string> Get()
    {
        // Retorna uma mensagem simples - TESTE HOT RELOAD! 🔥
        return Ok("🔥 HOT RELOAD funcionando! API Tormenta 20 rodando!");
    }

    // ====================================================
    // ENDPOINT 2: GET com parâmetro - Saudação personalizada
    // ====================================================
    // Responde a: GET /api/hello/João (onde João é o nome)
    [HttpGet("{nome}")]  // {nome} é um parâmetro da URL
    public ActionResult<string> GetComNome(string nome)
    {
        // Valida se o nome foi informado
        if (string.IsNullOrEmpty(nome))
        {
            return BadRequest("❌ Nome não pode ser vazio!");
        }

        // Retorna saudação personalizada
        return Ok($"👋 Olá, {nome}! Bem-vindo à API Artonium!");
    }

    // ====================================================
    // ENDPOINT 3: POST - Receber dados
    // ====================================================
    // Responde a: POST /api/hello com dados no corpo da requisição
    [HttpPost]  // Define que este método responde a requisições POST
    public ActionResult<string> Post([FromBody] MensagemRequest request)
    {
        // Valida se a mensagem foi enviada
        if (request?.Mensagem == null)
        {
            return BadRequest("❌ Mensagem é obrigatória!");
        }

        // Processa e retorna a resposta
        return Ok($"📨 Mensagem recebida: '{request.Mensagem}' - Muito obrigado!");
    }

    // ====================================================
    // ENDPOINT 4: GET - Informações da API
    // ====================================================
    // Responde a: GET /api/hello/info
    [HttpGet("info")]  // Rota específica: /api/hello/info
    public ActionResult<object> GetInfo()
    {
        // Retorna informações estruturadas sobre a API
        var info = new
        {
            Nome = "Artonium API",
            Versao = "1.0.0",
            Tecnologia = ".NET 8",
            Ambiente = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Desconhecido",
            DataHora = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"),
            Mensagem = "🚀 API funcionando perfeitamente!"
        };

        return Ok(info);
    }
}

// ====================================================
// MODELO DE DADOS (DTO - Data Transfer Object)
// ====================================================
// Define a estrutura dos dados que esperamos receber
public class MensagemRequest
{
    // Propriedade que representa a mensagem enviada pelo cliente
    public string? Mensagem { get; set; }
}
