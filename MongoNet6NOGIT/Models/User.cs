using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace MongoNet6NOGIT.Models
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("nick")] //Con el [BsonElement] atributo. El valor del atributo nick representa el nombre de la propiedad en la colección MongoDB.
        [JsonProperty("nick")]
        public string UserName { get; set; }

        [BsonElement("password")]
        public string Password { get; set; }
        
        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("lastname")]
        public string LastName { get; set; }

        [BsonElement("status")]
        public int Status { get; set; }
    }
}
