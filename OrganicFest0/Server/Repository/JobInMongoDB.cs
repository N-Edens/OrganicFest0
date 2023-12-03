using System;
using MongoDB.Driver;
using OrganicFest.Shared;
using OrganicFest.Server.Repository;

namespace OrganicFest.Server.Repository
{
    public class JobRepositoryMongoDB : IJob
    {
        private IMongoClient client;
        private IMongoCollection<Job> collection;

        public JobRepositoryMongoDB()
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
            var collectionName = "Afdeling";

            collection = client.GetDatabase(dbName)
               .GetCollection<Job>(collectionName);

        }


        public Job[] GetallJobs()
        {
            return collection.Find(Builders<Job>.Filter.Empty).ToList().ToArray();
        }
    }
}

