
using MongoDB.Bson.Serialization.Attributes;

namespace FootlooseFS.Models
{
    public class EntityDocument
    {
        [BsonElement("_id")]
        public int Id { get; set; }
    }
}
