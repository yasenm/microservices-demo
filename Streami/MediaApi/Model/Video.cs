using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace MediaApi.Model
{
    public class Video
    {
        [BsonIgnoreIfDefault]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public byte[] Content { get; set; }
        public string Title { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
