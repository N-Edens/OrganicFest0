using System;
using MongoDB.Driver;
using OrganicFest.Shared;

namespace OrganicFest.Server.Repository
{
    public class AfdelingRepositoryMongoDB : IAfdeling
    {
        private IMongoClient client;
        private IMongoCollection<Afdeling> collection;

        public AfdelingRepositoryMongoDB()
        {
            var mongoUri = $"mongodb+srv://mathiashvid:Boost1234@organic.rv52jkh.mongodb.net/";



            try
            {
                client = new MongoClient(mongoUri);
            }
            catch (Exception e)
            {
                Console.WriteLine("There was a problem connecting to your " +
                    "Atlas cluster. Check that the URI includes a valid " +
                    "username and password, and that your IP address is " +
                    $"in the Access List. Message: {e.Message}");
                Console.WriteLine(e);
                Console.WriteLine();
                return;
            }


            var dbName = "OrganicFestival";
            var collectionName = "Afdeling";

            collection = client.GetDatabase(dbName)
               .GetCollection<Afdeling>(collectionName);

        }

        // Henter alle afdelinger
        public Afdeling[] GetAllAfdelinger()
        {
            return collection.Find(Builders<Afdeling>.Filter.Empty).ToList().ToArray();
        }
    }
}

