using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Rebar.Modles
{
    public class OrderModle
    {

        [BsonId]
       [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get;  }
        // public Guid Id { get; }= Guid.NewGuid();
        public DateTime DateOfOrder { get; set; }
        public List<Shake>? Shakes { get; set; }
        public int TotalPrice { get; set; }
        public int Sale { get; set; }
        public string? CustomerName{ get; set; }
    }
}
