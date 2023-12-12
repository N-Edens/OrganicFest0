using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace OrganicFest.Shared
{
    public class Afdeling
    {
        [BsonId]  // Angiver at dette er ID-feltet i MongoDB
        [BsonRepresentation(BsonType.ObjectId)]  // Angiver repræsentationen af ID'en i BSON-format
        public string Id { get; set; } = string.Empty;  // Unik identifikator for string

        public string Afdelingsnavn { get; set; } = "";
    }
}

