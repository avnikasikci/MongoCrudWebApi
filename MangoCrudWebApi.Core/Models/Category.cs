using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MangoCrudWebApi.Core
{
    public class Category
    {
        public int Id { get; set; }
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ObjectId { get; set; }
        [BsonElement("name")]
        public string Name { get; set; }
        public string Description { get; set; }
        public string ParentCategoryOId { get; set; }
    }
}