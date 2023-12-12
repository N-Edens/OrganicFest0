﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using OrganicFest.Server.Repository;
using OrganicFest.Shared;
using MongoDB.Bson;
using MongoDB.Driver;

namespace OrganicFest.Server.Repository
{
    public class BrugerRepositoryMongoDB : IBruger
    {
        private IMongoClient client;
        private IMongoCollection<Bruger> collection;

        public BrugerRepositoryMongoDB()
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
               .GetCollection<Bruger>(collectionName);

        }

        public void AddBruger(Bruger bruger)
        {
            var existingFrivillig = collection.Find(Builders<Bruger>.Filter.Empty)
                .SortByDescending(r => r.FID)
                .Limit(1)
                .FirstOrDefault();

            if (existingFrivillig != null)
            {
                bruger.FID = existingFrivillig.FID + 1;
            }
            else
            {
                // Hvis samlingen er tom, start fra FID 1 eller en anden passende startværdi
                bruger.FID = 1;
            }

            collection.InsertOne(bruger);
        }


        public void DeleteBruger(int FID)
        {
            var deleteResult = collection
                .DeleteOne(Builders<Bruger>.Filter.Where(r => r.FID == FID));
        }

        public Bruger[] GetAllBruger()
        {
            return collection.Find(Builders<Bruger>.Filter.Empty).ToList().ToArray();
        }

        public void UpdateBruger(Bruger bruger)
        {
            var filter = Builders<Bruger>.Filter.Eq(f => f.FID, bruger.FID);
            var update = Builders<Bruger>.Update
                .Set(f => f.Name, bruger.Name)
                .Set(f => f.Telefonnummer, bruger.Telefonnummer)
                .Set(f => f.IsCoordinator, bruger.IsCoordinator)
                .Set(f => f.Password, bruger.Password)
                .Set(f => f.Email, bruger.Email);


            collection.UpdateOne(filter, update);
        }


        public async Task<Bruger> GetBrugerByEmail(string email)
        {
            var filter = Builders<Bruger>.Filter.Eq(x => x.Email, email);
            return await collection.Find(filter).FirstOrDefaultAsync();
        }

    }
}