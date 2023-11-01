using MongoDB.Driver;
using Rebar.Models;
using Rebar.Modles;

namespace Rebar.DataAccess
{
    public class OrderAccess
    {
        private const string ConnectionString = "mongodb://127.0.0.1:27017";
        private const string DatabeseName = "Rebar";
        private const string OrderCollectionName = "Orders";


        private IMongoCollection<T> ConnectToMongo<T>(in string collection)
        {
            var client = new MongoClient(ConnectionString);
            var db = client.GetDatabase(DatabeseName);
            return db.GetCollection<T>(collection);
        }

        public async Task<List<OrderModle>> GetAllOrders()
        {
            var orderCollection = ConnectToMongo<OrderModle>(OrderCollectionName);
            var result = await orderCollection.FindAsync(_ => true);
            return result.ToList();
        }
        public Task Creat(OrderModle order)
        {
            var orderCollection = ConnectToMongo<OrderModle>(OrderCollectionName);
            return orderCollection.InsertOneAsync(order);
        }
        public void UpdteOrder(Guid id,OrderModle order)
        {
            var orderCollection = ConnectToMongo<OrderModle>(OrderCollectionName);
            orderCollection.ReplaceOne(item=>item.Id==id, order);
        }
        public OrderModle CreatOrder(OrderModle order) 
        {
        Creat(order);
            order.TimeSince = order.DateOfOrder-DateTime.Now;
            order.DateOfOrder = DateTime.Now;
            UpdteOrder(order.Id, order);
            return order;

        }
    }
}
