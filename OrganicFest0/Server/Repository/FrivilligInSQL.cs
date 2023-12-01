using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Bambus.Server.Repositories;
using Bambus.Shared;
using MongoDB.Bson;
using MongoDB.Driver;

// Denne klasse håndterer interaktion med MongoDB for bookingdata
public class FrivilligRepository : Ifrivillig
{
    private readonly IMongoCollection<Frivillig> _frivillig;  // Kollektion til interaktion med MongoDB for bookingdata

    // Konstruktør: Etablere forbindelse til MongoDB og specificerer den kollektion, der skal bruges
    public FrivilligRepository()
    {
        MongoClient client = new MongoClient(
            @"mongodb+srv://mathiashvid:Boost1234@organic.rv52jkh.mongodb.net/");
        IMongoDatabase database = client.GetDatabase("OrganicFestival");
        _frivillig = database.GetCollection<Frivillig>("Frivillige");
    }

    public List<Frivillig> GetFrivilligs()
    {
        return _frivillig.Find(new BsonDocument()).ToList();
    }

    // Metode til at tilføje en booking til MongoDB asynkront
    public async Task AddFrivillig(Frivillig frivillig)
    {
        await _frivillig.InsertOneAsync(frivillig);
    }

    // Metode til at tilføje en booking til MongoDB asynkront
    public Task<IEnumerable<Frivillig>> GetAllFrivillige()
    {
        return new Task<IEnumerable<Frivillig>>(() => GetFrivilligs());
    }
}