using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Bambus.Shared
{
    public class Frivillig
    {
        [BsonId]  // Angiver at dette er ID-feltet i MongoDB
        [BsonRepresentation(BsonType.ObjectId)]  // Angiver repræsentationen af ID'en i BSON-format
        public string Id { get; set; } = string.Empty;  // Unik identifikator for string

        [BsonElement("FID")]
        public int FID { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string Telefonnummer { get; set; } = string.Empty;

        public string Rolle { get; set; } = string.Empty;



    }
}

