/*
 Student: Chelbaev Mikhail
 Group: BPI182_2
*/

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;

namespace Task
{
    class Program
    {
        static void Main(string[] args)
        {
            DataBase db = new DataBase("ShopDataBase");

            db.CreateTable<Good>();
            db.CreateTable<Shop>();
            db.CreateTable<Buyer>();
            db.CreateTable<Sales>();

            //shops
            db.InsertInto(new ShopFactory("Auchan", "Moscow", "Kotelniky", "Russia", "8 (800) 700-58-00"));
            db.InsertInto(new ShopFactory("Magnit", "Moscow", "Aeroport", "Russia", "8 (800) 432-34-03"));
            db.InsertInto(new ShopFactory("Magnit", "Saratov", "Center", "Russia", "8 (800) 353-75-93"));
            db.InsertInto(new ShopFactory("Magnit", "Madrid", "Center", "Spain", "8 (800) 353-75-93"));

            //goods
            db.InsertInto(new GoodFactory("Pepsi", 1, "fizzy drink", "beverages"));
            db.InsertInto(new GoodFactory("3 korochki", 1, "rusk", "food"));
            db.InsertInto(new GoodFactory("Ohota", 2, "beer", "beverages"));
            db.InsertInto(new GoodFactory("Lays", 3, "chips", "food"));

            //buyers
            db.InsertInto(new BuyerFactory("Petya", "Petrov", "Kochnovsii proezd, 3", "Moscow", "Aeroport",
                "Russia", 536789));
            db.InsertInto(new BuyerFactory("Ivan", "Ivanov", "Kochnovsii proezd, 3", "Moscow", "Aeroport",
                "Russia", 536789));

            Task1(db);
            Task2(db);
            Task3(db);
            Task4(db);
        }

        /// <summary>
        /// Task1
        /// </summary>
        /// <param name="db">database</param>
        private static void Task1(DataBase db)
        {
            db.InsertInto(new SalesFactory(customerId: 1, goodId: 1, shopId: 4, quantity: 2, cost: 200));
            db.InsertInto(new SalesFactory(2, 2, 3, 1, 100));
            db.InsertInto(new SalesFactory(2, 3, 2, 1, 150));
        }

        /// <summary>
        /// Task2
        /// </summary>
        /// <param name="db">database</param>
        private static void Task2(DataBase db)
        {
            WriteInFile<Shop>(db);
            WriteInFile<Good>(db);
            WriteInFile<Buyer>(db);
            WriteInFile<Sales>(db);

            //ShopFactory[] shops = ReadFromFile<ShopFactory>(@"..\..\..\DBShop.txt");
            //foreach (var shop in shops)
            //{
            //    db.InsertInto(shop);
            //}
        }

        /// <summary>
        /// Task 3
        /// </summary>
        /// <param name="db">database</param>
        private static void Task3(DataBase db)
        {
            //1
            var customerId = (from cus in db.Table<Buyer>()
                              orderby -cus.Name.Length
                              select cus.Id).First();
            var goodsId = (from g in db.Table<Sales>()
                           where g.CustomerId == customerId
                           select g.GoodId).ToArray();
            var goods = from g in db.Table<Good>()
                        from item in goodsId
                        where g.Id == item
                        select g.Name;
            Console.Write("1) Goods which were bought by the customer with the longest name: ");
            foreach (var item in goods)
            {
                Console.Write(item + " ");
            }

            //2
            var cost = (from sale in db.Table<Sales>()
                        orderby -sale.Cost
                        select sale.GoodId).First();
            var category = (from good in db.Table<Good>()
                            where good.Id == cost
                            select good.Category).First();
            Console.WriteLine("\n2) Category of the most expensive good: " + category);

            //3
            Console.Write("3) Cities with the smallest number of the sold goods: ");
            var orderByShop = from sale in db.Table<Sales>()
                              group sale by sale.ShopId into arr
                              select arr;
            var quantityInShop = (from sale in orderByShop
                                  select new { id = sale.First().ShopId, sum = sale.Sum(x => x.Quantity) });
            List<long> shops = new List<long>();
            foreach (var item in quantityInShop)
            {
                if (item.sum == quantityInShop.Min(x => x.sum))
                    shops.Add(item.id);
            }
            var cities = from id in shops
                         from shop in db.Table<Shop>()
                         where id == shop.Id
                         select shop.City;
            foreach (var item in cities)
            {
                Console.Write(item + " ");
            }

            //4
            Console.Write("\n4) Customers who bought the most popular good: ");
            var orderByGood = from sale in db.Table<Sales>()
                              group sale by sale.GoodId into arr
                              select arr;
            var quantity = (from sale in orderByGood
                            select new { id = sale.First().GoodId, sum = sale.Sum(x => x.Quantity) });
            List<long> popularGoods = new List<long>();
            foreach (var item in quantity)
            {
                if (item.sum == quantity.Max(x => x.sum))
                    popularGoods.Add(item.id);
            }
            var buyersId = from sale in db.Table<Sales>()
                           from good in popularGoods
                           where good == sale.GoodId
                           select sale.CustomerId;
            var buyers = from buyer in db.Table<Buyer>()
                         from id in buyersId
                         where id == buyer.Id
                         select buyer.Surname;
            foreach (var item in buyers)
            {
                Console.Write(item + " ");
            }

            //5
            var shopsGroupedByCountry = from shop in db.Table<Shop>()
                                        group shop by shop.Country into arr
                                        select arr;
            var shopsInCountries = from item in shopsGroupedByCountry
                                   select new { Country = item.First().Country, Number = item.Count() };
            var smallestNumber = shopsInCountries.Last().Number;
            Console.Write($"\n5) Countries with the smallest number of shops ({smallestNumber}): ");
            foreach (var item in shopsInCountries)
            {
                if (item.Number == smallestNumber)
                    Console.Write($"{item.Country} ");
            }

            //6
            var purchases = from sale in db.Table<Sales>()
                            from buyer in db.Table<Buyer>()
                            from shop in db.Table<Shop>()
                            where (sale.CustomerId == buyer.Id && sale.ShopId == shop.Id && shop.City != buyer.City)
                            select new
                            {
                                Customer = buyer.Surname,
                                CustomerCity = buyer.City,
                                ShopCity = shop.City
                            };
            Console.Write("\n6) ");
            foreach (var item in purchases)
            {
                Console.WriteLine($"{item.Customer} from {item.CustomerCity} made a purchase in {item.ShopCity}");
            }

            //7
            var totalCost = (from sale in db.Table<Sales>()
                             select sale.Cost).Sum();
            Console.WriteLine("7) Total cost: " + totalCost);
        }

        /// <summary>
        /// Task4
        /// </summary>
        /// <param name="db">database</param>
        private static void Task4(DataBase db)
        {
            Console.WriteLine("\n=======USER CONSOLE=======");
            while (true)
            {
                Console.WriteLine("Commands: \n1 - add new entity\n2 - save table as a json file" +
                    " \n3 - print a table\nESC - exit");
                var key = Console.ReadKey().Key;
                Console.Clear();
                switch (key)
                {
                    case ConsoleKey.D1:
                        AddTable(db);
                        break;
                    case ConsoleKey.D2:
                        SaveTable(db);
                        break;
                    case ConsoleKey.D3:
                        PrintTable(db);
                        break;
                    case ConsoleKey.Escape:
                        return;
                    default:
                        Console.WriteLine("There is no action for this command, please try again!");
                        break;
                }
            }
        }

        /// <summary>
        /// Writes table in file
        /// </summary>
        /// <typeparam name="T">IEntity</typeparam>
        /// <param name="db">database</param>
        private static void WriteInFile<T>(DataBase db) where T : IEntity
        {
            string path = $@"..\..\..\DB{typeof(T).ToString().Split('.')[1]}.txt";

            try
            {
                using (FileStream file = new FileStream(path, FileMode.Create))
                {
                    DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(T[]));
                    jsonSerializer.WriteObject(file, db.Table<T>().ToArray());
                    Console.WriteLine("File was successfully saved!");
                }
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        /// <summary>
        /// Reads table from file
        /// </summary>
        /// <typeparam name="T">IEntity</typeparam>
        /// <param name="path">path to the file</param>
        /// <returns>table</returns>
        private static T[] ReadFromFile<T>(string path)
        {
            T[] instance = null;
            try
            {
                using (FileStream file = new FileStream(path, FileMode.Open))
                {
                    DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(T[]));
                    instance = (T[])jsonSerializer.ReadObject(file);
                    Console.WriteLine("File was successfully uploaded!");
                }
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return instance;
        }

        /// <summary>
        /// Adds the table
        /// </summary>
        /// <param name="db">database</param>
        private static void AddTable(DataBase db)
        {
            Console.WriteLine("Input name of the table which you want to add (sales, buyer, good, shop): ");
            string tableName = Console.ReadLine().ToLower();
            switch (tableName)
            {
                case "sales":
                    Console.WriteLine("Input customer ID: ");
                    long.TryParse(Console.ReadLine(), out long customerId);
                    Console.WriteLine("Input shop ID: ");
                    long.TryParse(Console.ReadLine(), out long shopId);
                    Console.WriteLine("Input good ID: ");
                    long.TryParse(Console.ReadLine(), out long gooId);
                    Console.WriteLine("Input quantity: ");
                    int.TryParse(Console.ReadLine(), out int quantity);
                    Console.WriteLine("Input cost: ");
                    int.TryParse(Console.ReadLine(), out int cost);
                    db.InsertInto(new SalesFactory(customerId, shopId, gooId, quantity, cost));
                    break;
                case "buyer":
                    Console.WriteLine("Input custmer name: ");
                    string name = Console.ReadLine();
                    Console.WriteLine("Input custmer surname: ");
                    string surname = Console.ReadLine();
                    Console.WriteLine("Input custmer address: ");
                    string address = Console.ReadLine();
                    Console.WriteLine("Input custmer city: ");
                    string city = Console.ReadLine();
                    Console.WriteLine("Input custmer area: ");
                    string area = Console.ReadLine();
                    Console.WriteLine("Input custmer country: ");
                    string country = Console.ReadLine();
                    Console.WriteLine("Input custmer postcode: ");
                    int.TryParse(Console.ReadLine(), out int postcode);
                    db.InsertInto(new BuyerFactory(name, surname, address, city, area, country, postcode));
                    break;
                case "good":
                    Console.WriteLine("Input good name: ");
                    name = Console.ReadLine();
                    Console.WriteLine("Input good shopId: ");
                    long.TryParse(Console.ReadLine(), out long shop);
                    Console.WriteLine("Input good description: ");
                    string description = Console.ReadLine();
                    Console.WriteLine("Input good category: ");
                    string category = Console.ReadLine();
                    db.InsertInto(new GoodFactory(name, shop, description, category));
                    break;
                case "shop":
                    Console.WriteLine("Input shop name: ");
                    name = Console.ReadLine();
                    Console.WriteLine("Input shop city: ");
                    city = Console.ReadLine();
                    Console.WriteLine("Input shop area: ");
                    area = Console.ReadLine();
                    Console.WriteLine("Input shop country: ");
                    country = Console.ReadLine();
                    Console.WriteLine("Input shop phone number: ");
                    string phone = Console.ReadLine();
                    db.InsertInto(new ShopFactory(name, city, area, country, phone));
                    break;
                default:
                    Console.WriteLine("Error occurred. There is no table with the such name!");
                    return;
            }
            Console.WriteLine("Table was successfylly created!");
        }

        /// <summary>
        /// Saves the table
        /// </summary>
        /// <param name="db">database</param>
        private static void SaveTable(DataBase db)
        {
            Console.WriteLine("Input name of the table which you want to save (sales, buyer, good, shop): ");
            string tableName = Console.ReadLine().ToLower();
            switch (tableName)
            {
                case "sales":
                    WriteInFile<Sales>(db);
                    break;
                case "buyer":
                    WriteInFile<Buyer>(db);
                    break;
                case "good":
                    WriteInFile<Good>(db);
                    break;
                case "shop":
                    WriteInFile<Shop>(db);
                    break;
                default:
                    Console.WriteLine("Error occurred. There is no table with the such name!");
                    break;
            }
        }

        /// <summary>
        /// Dispay the table
        /// </summary>
        /// <param name="db">database</param>
        private static void PrintTable(DataBase db)
        {
            Console.WriteLine("Input name of the table which you want to display (sales, buyer, good, shop): ");
            string tableName = Console.ReadLine().ToLower();
            switch (tableName)
            {
                case "sales":
                    PrintLine();
                    PrintRow(new string[] { "Id", "CustomerId", "ShopId", "GoodId", "Quantity", "Cost" });
                    PrintLine();
                    foreach (var sale in db.Table<Sales>())
                    {
                        PrintRow(new string[] { sale.Id.ToString(),sale.CustomerId.ToString(),
                            sale.ShopId.ToString(),sale.GoodId.ToString(),sale.Quantity.ToString(),
                            sale.Cost.ToString() });
                        PrintLine();
                    }
                    break;
                case "buyer":
                    PrintLine();
                    PrintRow(new string[] { "Id", "Name", "Surname", "Address", "City", "Area", "Country",
                    "Postcode"});
                    PrintLine();
                    foreach (var buyer in db.Table<Buyer>())
                    {
                        PrintRow(new string[] { buyer.Id.ToString(), buyer.Name, buyer.Surname, buyer.Address,
                        buyer.City, buyer.Area, buyer.Country, buyer.Postcode.ToString()});
                        PrintLine();
                    }
                    break;
                case "good":
                    PrintLine();
                    PrintRow(new string[] { "Id", "Name", "ShopId", "Description", "Category" });
                    PrintLine();
                    foreach (var good in db.Table<Good>())
                    {
                        PrintRow(new string[] { good.Id.ToString(), good.Name, good.ShopId.ToString(),
                        good.Description, good.Category});
                        PrintLine();
                    }
                    break;
                case "shop":
                    PrintLine();
                    PrintRow(new string[] { "Id", "Name", "City", "Area", "Country", "Phone" });
                    PrintLine();
                    foreach (var shop in db.Table<Shop>())
                    {
                        PrintRow(new string[] { shop.Id.ToString(), shop.Name, shop.City, shop.Area,
                        shop.Country, shop.Phone});
                        PrintLine();
                    }
                    break;
                default:
                    Console.WriteLine("Error occurred. There is no table with the such name!");
                    break;
            }
        }

        #region code for printing tables
        /// <summary>
        /// width of the table on the screen
        /// </summary>
        static int tableWidth = 90;

        /// <summary>
        /// Prints the line
        /// </summary>
        static void PrintLine()
        {
            Console.WriteLine(new string('-', tableWidth));
        }

        /// <summary>
        /// Prints the row
        /// </summary>
        /// <param name="columns"></param>
        static void PrintRow(params string[] columns)
        {
            int width = (tableWidth - columns.Length) / columns.Length;
            string row = "|";

            foreach (string column in columns)
            {
                row += AlignCentre(column, width) + "|";
            }

            Console.WriteLine(row);
        }

        /// <summary>
        /// Aligns the string in the center of the cell
        /// </summary>
        /// <param name="text">text</param>
        /// <param name="width">width</param>
        /// <returns>string</returns>
        static string AlignCentre(string text, int width)
        {
            text = text.Length > width ? text.Substring(0, width - 3) + "..." : text;

            if (string.IsNullOrEmpty(text))
            {
                return new string(' ', width);
            }
            else
            {
                return text.PadRight(width - (width - text.Length) / 2).PadLeft(width);
            }
        }
        #endregion
    }
}


