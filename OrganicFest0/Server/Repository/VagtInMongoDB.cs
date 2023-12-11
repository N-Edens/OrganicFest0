using System;
using MongoDB.Driver;
using OrganicFest.Shared;
using OrganicFest.Server.Repository;
using System.Xml.Linq;

namespace OrganicFest.Server.Repository
{
    public class VagtRepositoryMongoDB : IVagt
    {
        private IMongoClient client;
        private IMongoCollection<Vagt> collection;

        public VagtRepositoryMongoDB()
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
            var collectionName = "Vagter";

            collection = client.GetDatabase(dbName)
               .GetCollection<Vagt>(collectionName);

        }

        public void AddVagt(Vagt vagt)
        {
            var existingVagt = collection.Find(Builders<Vagt>.Filter.Empty)
                .SortByDescending(r => r.VID)
                .Limit(1)
                .FirstOrDefault();

            if (existingVagt != null)
            {
                vagt.VID = existingVagt.VID + 1;
            }
            else
            {
                // Hvis samlingen er tom, start fra FID 1 eller en anden passende startværdi
                vagt.VID = 1;
            }

            collection.InsertOne(vagt);
        }

        public void DeleteVagt(int VID)
        {
            var deleteResult = collection
                .DeleteOne(Builders<Vagt>.Filter.Where(v => v.VID == VID));
        }

        public Vagt[] GetAllVagts()
        {
            return collection.Find(Builders<Vagt>.Filter.Empty).ToList().ToArray();
        }

        public void UpdateVagt(Vagt vagt)
        {
            var updateFID = Builders<Vagt>.Update.Set(v => v.FID, vagt.FID);
            var updateJobnavn = Builders<Vagt>.Update
                .Set(v => v.Jobnavn, vagt.Jobnavn)
                .Set(v => v.Description, vagt.Description)
                .Set(v => v.Startdate, vagt.Startdate)
                .Set(v => v.Enddate, vagt.Enddate);
            collection.UpdateOne(v => v.VID == vagt.VID, updateFID);
            collection.UpdateOne(v => v.VID == vagt.VID, updateJobnavn);
        }


    }
}
