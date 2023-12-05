using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace OrganicFest.Shared
{
    public class Vagt
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = "";

        [BsonElement("FID")]
        public int FID { get; set; }  // Add this property to store Frivillig ID

        public int VID { get; set; }

        [BsonElement("Jobnavn")]
        public string Jobnavn { get; set; } = "";

        public string Description { get; set; } = string.Empty;

        public DateTime? Startdate { get; set; } = null;

        public DateTime? Enddate { get; set; } = null;

        public bool? Priority { get; set; }
        [BsonIgnore]
        public string PriorityAsString
        {
            get => Priority.HasValue ? Priority.ToString() : "";
            set => Priority = value switch
            {
                "True" => true,
                "False" => false,
                _ => null
            };
        }

        // Constructor
        public Vagt()
        {
            Startdate = DateTime.Now;
        }
    }
}

