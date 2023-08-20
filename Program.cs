namespace MongoDb
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //MongoDataHandler mongoDataHandler = new MongoDataHandler(Environment.GetEnvironmentVariable("ConnectionString")!);
            MongoDataHandler mongoDataHandler = new MongoDataHandler("mongodb://localhost:27017");


            List<MongoObject> cakesWithinThreshold = mongoDataHandler.GetCakesWithinThreshold(30);

            Console.WriteLine("Cakes that can be made in 30 minutes or less: \n");

            foreach (MongoObject item in cakesWithinThreshold)
            {
                Console.WriteLine(item.Name + "\n");
            }

            bool menuBool = true;

            Console.WriteLine("Write a cake's name to see details, press enter to search \n");

            MongoObject specificCake;

            while (menuBool)
            {
                string input = Console.ReadLine()!;

                if (input.Length > 1)
                {
                    if (Console.ReadKey().Key == ConsoleKey.Enter)
                    {
                        specificCake = mongoDataHandler.GetCakeByName(input);
                        Console.WriteLine("Name: " + specificCake.Name + "\n");
                        Console.WriteLine("Ingredients: \n");
                        foreach (string item in specificCake.Ingredients)
                        {
                            Console.WriteLine(item + "\n");
                        }
                        Console.WriteLine("Time to make: " + specificCake.TimeToMake + "\n");
                        Console.WriteLine("Description: " + specificCake.Description + "\n");
                        menuBool = false;
                    }
                }
            }

            menuBool = true;

            Console.WriteLine("Write a cakes name to delete it \n");

            while (menuBool)
            {
                string input = Console.ReadLine()!;

                if (input.Length > 1)
                {
                    if (Console.ReadKey().Key == ConsoleKey.Enter)
                    {
                        specificCake = mongoDataHandler.DeleteCakeByName(input);
                        if (!specificCake.Equals(null))
                        {
                            Console.WriteLine("Name: " + specificCake.Name + "\n");
                            Console.WriteLine("Ingredients: \n");
                            foreach (string item in specificCake.Ingredients)
                            {
                                Console.WriteLine(item + "\n");
                            }
                            Console.WriteLine("Time to make: " + specificCake.TimeToMake + "\n");
                            Console.WriteLine("Description: " + specificCake.Description + "\n");
                            Console.WriteLine("Was deleted from the database");
                        }
                        else
                        {
                            Console.WriteLine("Something went wrong when trying to delete");
                        }

                        menuBool = false;
                    }
                }
            }
        }
    }
}