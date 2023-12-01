﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Bambus.Shared
{
    public class Vagt
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = "";

        [BsonElement("FID")]
        public int FID { get; set; }

        public int VID { get; set; }

        [BsonElement("Jobnavn")]
        public string Jobnavn { get; set; } = "";

        public string Description { get; set; } = string.Empty;

        public DateTime? Startdate { get; set; } = null;

        public DateTime? Enddate { get; set; } = null;

        // Constructor
        public Vagt()
        {
            Startdate = DateTime.Now;
        }
    }
}
