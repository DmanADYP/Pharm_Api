using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace WebAPI.Models
{
    public class PropertiesModel
    {

        [BsonElement("Id")]
        public string? Id { get; set; }
        [BsonElement("Name")]
        public string? Name { get; set; }
        [BsonElement("Values")]
        public string? Values { get; set; }
        [BsonElement("Deprecated")]
        public bool Deprecated { get; set; } = false;

    }
}
