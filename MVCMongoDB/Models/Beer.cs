using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCMongoDB.Models
{
    public class Beer
    {
        [BsonId] //con esto, mongoDb va a saber que este es el id
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("alcohol")]
        public decimal Alcohol { get; set; }
    }
}
