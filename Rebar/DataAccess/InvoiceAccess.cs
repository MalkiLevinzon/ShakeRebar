using MongoDB.Driver;
using Rebar.Modles;

namespace Rebar.DataAccess
{
    public class InvoiceAccess
    {
        private const string ConnectionString = "mongodb://127.0.0.1:27017";
        private const string DatabeseName = "Rebar";
        private const string InvoiceCollectionName = "Invoice";


        private IMongoCollection<T> ConnectToMongo<T>(in string collection)
        {
            var client = new MongoClient(ConnectionString);
            var db = client.GetDatabase(DatabeseName);
            return db.GetCollection<T>(collection);
        }
        public async Task<List<InvoiceModle>> GetAllInvoice()
        {
            var invoiceCollection = ConnectToMongo<InvoiceModle>(InvoiceCollectionName);
            var result = await invoiceCollection.FindAsync(_ => true);
            return result.ToList();
        }
        public Task Creat(InvoiceModle invoice)
        {
            var invoiceCollection = ConnectToMongo<InvoiceModle>(InvoiceCollectionName);
            return invoiceCollection.InsertOneAsync(invoice);
        }
      
        public InvoiceModle CreatInvoice()
        {
            InvoiceModle invoice=new InvoiceModle();
            invoice.ClosingTheCheckout();
          Creat(invoice);
            return invoice;


        }
    }
}

