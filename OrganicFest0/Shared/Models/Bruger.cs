using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace OrganicFest.Shared
{
    public class Bruger
    {
        [BsonId]  
        [BsonRepresentation(BsonType.ObjectId)] 
        public string Id { get; set; } = string.Empty;  

        public int FID { get; set; }

        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; } = "";

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; } = "";

        public bool IsCoordinator { get; set; } = false;

        public string Name { get; set; } = string.Empty;

        public int Telefonnummer { get; set; }


    }
}

