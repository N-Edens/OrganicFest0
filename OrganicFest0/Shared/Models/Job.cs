using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Bambus.Shared
{
    public class Job
    {
        [BsonId]  // Angiver at dette er ID-feltet i MongoDB
        [BsonRepresentation(BsonType.ObjectId)]  // Angiver repræsentationen af ID'en i BSON-format
        public string Id { get; set; } = string.Empty;  // Unik identifikator for string

        public string Jobnavn { get; set; } = "";

        [BsonElement("FID")]
        public int FID;
    }
}

