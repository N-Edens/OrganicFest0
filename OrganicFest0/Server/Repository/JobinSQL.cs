using System.Text.Json;
using mini.Repositories;
using Bambus.Shared;
using MongoDB.Bson;
using MongoDB.Driver;
using Bambus.Server.Repositories;

namespace mini.Repositories;

public class JobRepository : IJob

{
    // Strengvariabler, der indeholder forbindelsesoplysninger til MongoDB-databasen
    private const string connectionString =
        @"mongodb+srv://mathiashvid:Boost1234@organic.rv52jkh.mongodb.net/";
    private const string databaseName = "OrganicFestival";
    private const string collectionName = "Afdeling";

    private IMongoCollection<Job> collection; // MongoDB-samling til Shelter-oplysninger

    // Konstruktøren opretter forbindelse til MongoDB-databasen og dens samlinger
    public JobRepository()
    {
        var client = new MongoClient(connectionString); // Opretter en klient til MongoDB-serveren
        var database = client.GetDatabase(databaseName);  // Får adgang til den ønskede database
        collection = database.GetCollection<Job>(collectionName); // Får adgang til Shelter-samlingen
    }

    // Metode til at hente alle Shelters fra MongoDB og returnere dem som en liste
    public List<Job> GetJobs()
    {
        return collection.Find(new BsonDocument()).ToList();  // Finder og returnerer alle Shelters
    }

}