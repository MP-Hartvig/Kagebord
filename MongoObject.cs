using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using MongoDB.Driver.GridFS;

namespace MongoDb
{
    internal class MongoObject
    {
        [BsonId, BsonElement("objectId"), BsonRepresentation(BsonType.ObjectId)]
        public string _objectId { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("ingredients")]
        public string[] Ingredients { get; set; }

        [BsonElement("timeToMake")]
        public float TimeToMake { get; set; }

        [BsonElement("description")]
        public string Description { get; set; }
    }

    internal class MongoDataHandler
    {
        GridFSBucket fs;
        IMongoDatabase imdb;
        MongoClient mongoClient;
        string collectionName = "Cakes";
        string databaseName = "CakeDb";
        //string collectionName = Environment.GetEnvironmentVariable("CollectionName")!;
        //string databaseName = Environment.GetEnvironmentVariable("CakeDb")!;

        public MongoDataHandler(string conString)
        {
            mongoClient = new MongoClient(conString);
            imdb = mongoClient.GetDatabase(databaseName);
            fs = new GridFSBucket(imdb);
        }

        public List<MongoObject> GetCakesWithinThreshold(int timeToMake)
        {
            return fs.Database.GetCollection<MongoObject>(collectionName).Find(x => x.TimeToMake <= timeToMake).ToList();
        }

        public MongoObject GetCakeByName(string name)
        {
            return fs.Database.GetCollection<MongoObject>(collectionName).Find(x => x.Name == name).FirstOrDefault();
        }

        public MongoObject DeleteCakeByName(string name)
        {
            return fs.Database.GetCollection<MongoObject>(collectionName).FindOneAndDelete(x => x.Name == name);
        }

        public void InsertInitialData()
        {
            IEnumerable<MongoObject> dataToSave = CreateData();
            UploadList(fs, dataToSave, collectionName);
        }

        private void UploadList(GridFSBucket fs, IEnumerable<MongoObject> list, string collectionName)
        {
            fs.Database.GetCollection<MongoObject>(collectionName).InsertMany(list);
        }

        private IEnumerable<MongoObject> CreateData()
        {
            List<MongoObject> cakes = new List<MongoObject>();

            cakes.Add(new MongoObject
            {
                Name = "Brunsviger",
                Ingredients = new string[] { "Gær", "Mel", "Farin", "Smør" },
                TimeToMake = 30,
                Description = "En blød gærdej med en topping af brun farin og smør."
            });

            cakes.Add(new MongoObject
            {
                Name = "Hindbærsnitter",
                Ingredients = new string[] { "Gær", "Mel", "Hindbær", "Sukker" },
                TimeToMake = 20,
                Description = "To lag mørdej med hindbærsyltetøj i midten og glasur ovenpå."
            });

            cakes.Add(new MongoObject
            {
                Name = "Kiksekage",
                Ingredients = new string[] { "Chokolade", "Smør", "Kiks" },
                TimeToMake = 40,
                Description = "En kold kage lavet af smør, chokolade og knuste kiks."
            });

            cakes.Add(new MongoObject
            {
                Name = "Gåsebryst",
                Ingredients = new string[] { "Mælk", "Smør", "Chokolade" },
                TimeToMake = 15,
                Description = "En flødeskumskage med mørk chokoladeovertræk."
            });

            cakes.Add(new MongoObject
            {
                Name = "Fedtebrød",
                Ingredients = new string[] { "Sukker", "Smør", "Mel", "Mandler" },
                TimeToMake = 45,
                Description = "En småkage med sukker og mandler ovenpå."
            });

            cakes.Add(new MongoObject
            {
                Name = "Krydderkage",
                Ingredients = new string[] { "Mel", "Smør", "Rosiner", "Mandler" },
                TimeToMake = 35,
                Description = "En småkage med sukker og mandler ovenpå."
            });

            cakes.Add(new MongoObject
            {
                Name = "Napoleonskage",
                Ingredients = new string[] { "Mel", "Smør", "Flødeskum", "Syltetøj", "Sukker" },
                TimeToMake = 45,
                Description = "En lagkage bestående af flaky dej, flødeskum, syltetøj og glasur."
            });

            cakes.Add(new MongoObject
            {
                Name = "Kanelstang",
                Ingredients = new string[] { "Smør", "Gær", "Kanel", "Sukker", "Flormelis" },
                TimeToMake = 30,
                Description = "Gærdej fyldt med remonce og kanelsukker, toppet med glasur."
            });

            cakes.Add(new MongoObject
            {
                Name = "Sandkage",
                Ingredients = new string[] { "Smør", "Gær", "Sukker" },
                TimeToMake = 20,
                Description = "En simpel, men lækker kage lavet med masser af smør."
            });

            cakes.Add(new MongoObject
            {
                Name = "Mazarinkage",
                Ingredients = new string[] { "Smør", "Gær", "Sukker", "Chokolade", "Mandler" },
                TimeToMake = 20,
                Description = "En tæt kage lavet med mandelessens og ofte overtrukket med\r\nchokolade."
            });

            Console.WriteLine(cakes.Count);

            return cakes;
        }
    }
}
