using MongoDB.Driver;
using MongoDB.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace MongoDb
{
    internal class MongoObject : Entity
    {
        public string Name { get; set; }

        public string[] Ingredients { get; set; }

        public float TimeToMake { get; set; }

        public string Description { get; set; }
    }

    internal class MongoDataHandler 
    {
        //public bool Upload(IMongoCollection<MongoObject> collection, MongoObject cake)
        //{
        //    return TryInsertion(collection, cake);
        //}

        private bool TryInsertion(IMongoCollection<MongoObject> collection, List<MongoObject> cakes)
        {
            try
            {
                collection.InsertMany(cakes);
                return true;

            }
            catch (Exception e)
            {
                return false;
            }
        }

        public async void CreateData(IMongoCollection<MongoObject> collection)
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

            await cakes.SaveAsync();
        }
    }
}
