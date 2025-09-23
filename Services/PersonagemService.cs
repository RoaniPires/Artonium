// ====================================================
// SERVIÇO DE PERSONAGEM - MONGODB
// ====================================================
// Responsável por acessar a coleção de personagens no MongoDB


using ArtoniumApi.Models;
using MongoDB.Driver;
using MongoDB.Bson;

namespace ArtoniumApi.Services;

public class PersonagemService
{
    private readonly IMongoCollection<Personagem> _personagens;

    public PersonagemService(IMongoClient mongoClient)
    {
        var database = mongoClient.GetDatabase("artonium");
        _personagens = database.GetCollection<Personagem>("personagens");
    }

    public async Task<List<Personagem>> GetAllAsync()
        => await _personagens.Find(_ => true).SortBy(p => p.Nome).ToListAsync();


    public async Task<Personagem?> GetByIdAsync(string id)
    {
        if (!ObjectId.TryParse(id, out var objectId)) return null;
        return await _personagens.Find(p => p.Id == objectId).FirstOrDefaultAsync();
    }

    public async Task CreateAsync(Personagem personagem)
        => await _personagens.InsertOneAsync(personagem);


    public async Task UpdateAsync(string id, Personagem personagem)
    {
        if (!ObjectId.TryParse(id, out var objectId)) return;
        personagem.Id = objectId;
        await _personagens.ReplaceOneAsync(p => p.Id == objectId, personagem);
    }


    public async Task DeleteAsync(string id)
    {
        if (!ObjectId.TryParse(id, out var objectId)) return;
        await _personagens.DeleteOneAsync(p => p.Id == objectId);
    }
}
