using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Rebar.Modles
{
    public class OrderModle
    {

        [BsonId]
        [BsonRepresentation(BsonType.String)]
        // public string? Id { get;  }
        public Guid Id { get; } = Guid.NewGuid();
        public DateTime DateOfOrder { get; set; }
        public TimeSpan? TimeSince { get; set; }
        public List<Shake>? Shakes { get; set; }
        public int TotalPrice { get; set; }
        public int Sale { get; set; }
        public string? CustomerName { get; set; }
        public OrderModle(List<Shake> shakes, int sale, string customerName)
        {
            DateOfOrder = DateTime.Now;
            if (shakes.Count == 0) throw new ArgumentException("Hi, you didn't choose a shake");
            if (shakes.Count > 10) throw new ArgumentException("Hi, you chose too many puffed shakes from the order");
            Shakes = shakes;
            Sale = sale;
            CustomerName = customerName;
            int price = 0;
            shakes.ForEach(shake => price += shake.Price);
            TotalPrice = price;
            TimeSince = null;
        }
    }
}
