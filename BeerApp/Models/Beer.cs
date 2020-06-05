using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;


namespace BeerApp.Models
{
    public class Beer
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string objectid { get; set; }

        public long id { get; set; }


    }

}

