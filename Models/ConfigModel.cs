//using MongoDB.Bson;

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace WebAPI.Models
{
    public class ConfigModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        [BsonElement("Name")]

        public string? Name { get; set; }
        [BsonElement("Value")]

        public string? Value { get; set; }
        [BsonElement("Deprecated")]

        public bool Deprecated { get; set; } = false;
        [BsonElement("Properties")]

        public IList<PropertiesModel>? Properties { get; set; }
    }
}
