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
                Console.WriteLine(e);
                Console.WriteLine();
                return;
            }
            var dbName = "OrganicFestival";
            var collectionName = "Vagter";

            collection = client.GetDatabase(dbName)
               .GetCollection<Vagt>(collectionName);

        }

        // gør at når man opretter ny vagt får de et nyt Vagt ID, som er en højere end den højeste, hvis ingen brugere findes vil den starte på 1
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
                vagt.VID = 1;
            }

            collection.InsertOne(vagt);
        }
        // fjerner bruger hvor vagt.VID = VID
        public void DeleteVagt(int VID)
        {
            var deleteResult = collection
                .DeleteOne(Builders<Vagt>.Filter.Where(v => v.VID == VID));
        }

        public Vagt[] GetAllVagts()
        {
            return collection.Find(Builders<Vagt>.Filter.Empty).ToList().ToArray();
        }
        
        // Opdatere element sådan at ens bruger FID kan blive en del af vagt
        // Opdatere forskellige attributer, sådan man kan opdatere dem på siden
        public void UpdateVagt(Vagt vagt)
        {
            var updateFID = Builders<Vagt>.Update.Set(v => v.FID, vagt.FID);
            var updateAfdelingsnavn = Builders<Vagt>.Update
                .Set(v => v.Afdelingsnavn, vagt.Afdelingsnavn)
                .Set(v => v.Beskrivelse, vagt.Beskrivelse)
                .Set(v => v.Startdate, vagt.Startdate)
                .Set(v => v.Priority, vagt.Priority)
                .Set(v => v.Enddate, vagt.Enddate);
            collection.UpdateOne(v => v.VID == vagt.VID, updateFID);
            collection.UpdateOne(v => v.VID == vagt.VID, updateAfdelingsnavn);
        }

    }
}
