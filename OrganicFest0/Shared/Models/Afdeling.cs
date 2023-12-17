using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace OrganicFest.Shared
{
    public class Afdeling
    {
        [BsonId]  
        [BsonRepresentation(BsonType.ObjectId)]  
        public string Id { get; set; } = string.Empty;  

        public string Afdelingsnavn { get; set; } = "";
    }
}

