using MongoDB.Driver;

namespace MongoDb
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MongoClient client = new MongoClient("mongodb://localhost:27017");

            MongoDataHandler mongoDataHandler = new MongoDataHandler();

            var db = client.GetDatabase("CakeDb");
            var collection = db.GetCollection<MongoObject>("Cakes");

            mongoDataHandler.CreateData(collection);
        }
    }
}