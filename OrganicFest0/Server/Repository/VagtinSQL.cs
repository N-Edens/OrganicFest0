using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Bambus.Server.Repositories;
using Bambus.Shared;
using MongoDB.Bson;
using MongoDB.Driver;

// Denne klasse håndterer interaktion med MongoDB for bookingdata
public class VagtRepository : IVagt
{
    private readonly IMongoCollection<Vagt> _vagt;  // Kollektion til interaktion med MongoDB for bookingdata

    // Konstruktør: Etablere forbindelse til MongoDB og specificerer den kollektion, der skal bruges
    public VagtRepository()
    {
        MongoClient client = new MongoClient(
            @"mongodb+srv://mathiashvid:Boost1234@organic.rv52jkh.mongodb.net/");
        IMongoDatabase database = client.GetDatabase("OrganicFestival");
        _vagt = database.GetCollection<Vagt>("Vagter");
    }

    public List<Vagt> GetVagts()
    {
        return _vagt.Find(new BsonDocument()).ToList();
    }

    // Metode til at tilføje en booking til MongoDB asynkront
    public async Task AddVagt(Vagt vagt)
    {
        await _vagt.InsertOneAsync(vagt);
    }

    // Metode til at tilføje en booking til MongoDB asynkront
    public Task<IEnumerable<Vagt>> GetAllVagts()
    {
        return new Task<IEnumerable<Vagt>>(() => GetVagts());
    }
}