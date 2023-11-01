using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Rebar.Models
{
    public class ShakeModle
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
       // public string? Id { get;  }
        public Guid Id { get; }= Guid.NewGuid();
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int PriceL { get; set; }
        public int PriceM { get; set; }
        public int PriceS { get; set; }
        public ShakeModle(string name,string description,int priceL, int pricem, int priceS)
        {
            Name = name;Description = description; PriceL = priceL;PriceM=pricem; PriceS=priceS;
        }

    }
}
