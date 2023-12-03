using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using OrganicFest.Server.Repository;
using OrganicFest.Shared;
using MongoDB.Bson;
using MongoDB.Driver;

namespace OrganicFest.Server.Repository
{
    public class FrivilligRepositoryMongoDB : Ifrivillig
    {
        private IMongoClient client;
        private IMongoCollection<Frivillig> collection;

        public FrivilligRepositoryMongoDB()
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

            // Provide the name of the database and collection you want to use.
            // If they don't already exist, the driver and Atlas will create them
            // automatically when you first write data.
            var dbName = "OrganicFestival";
            var collectionName = "Frivillige";

            collection = client.GetDatabase(dbName)
               .GetCollection<Frivillig>(collectionName);

        }

        public void AddFrivillig(Frivillig frivillig)
        {
            var existingFrivillig = collection.Find(Builders<Frivillig>.Filter.Empty)
                .SortByDescending(r => r.FID)
                .Limit(1)
                .FirstOrDefault();

            if (existingFrivillig != null)
            {
                frivillig.FID = existingFrivillig.FID + 1;
            }
            else
            {
                // Hvis samlingen er tom, start fra FID 1 eller en anden passende startværdi
                frivillig.FID = 1;
            }

            collection.InsertOne(frivillig);
        }


        public void DeleteFrivillig(int FID)
        {
            var deleteResult = collection
                .DeleteOne(Builders<Frivillig>.Filter.Where(r => r.FID == FID));
        }

        public Frivillig[] GetAllFrivillige()
        {
            return collection.Find(Builders<Frivillig>.Filter.Empty).ToList().ToArray();
        }

        public void UpdateFrivillig(Frivillig frivillig)
        {
            throw new NotImplementedException();
        }
        // Ny metode til at hente en frivillig baseret på e-mail
        public async Task<Frivillig> GetFrivilligByEmail(string email)
        {
            var filter = Builders<Frivillig>.Filter.Eq(x => x.Email, email);
            return await collection.Find(filter).FirstOrDefaultAsync();
        }
    }
}