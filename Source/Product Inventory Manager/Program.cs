using System;

namespace Product_Inventory_Manager
{
    class Program
    {
        static void Main(string[] args)
        {
            var inventoryList = new Inventory();
            var product = new Product("Stool", 65m, 1, 2);
            var product2 = new Product("Bench", 125m, 2, 3);
            var product3 = new Product("Wrench", 30m, 3, 5);
            var product4 = new Product("Tire Iron", 36m, 4, 3);
            var product5 = new Product("Adjustable Wrench", 40m, 5, 4);

            inventoryList.AddProduct(1, product);
            inventoryList.AddProduct(2, product2);
            inventoryList.AddProduct(3, product3);
            inventoryList.AddProduct(4, product4);
            inventoryList.AddProduct(5, product5);

            while (true)
            {
                Console.WriteLine("Initializing Product Inventory...");
                Console.WriteLine("Welcome to the Product Inventory Manager.");
                Console.WriteLine("Select your operation.");
                Console.WriteLine("1. Sell Product");
                Console.WriteLine("2. Stock Product");
                Console.WriteLine("3. Product Inventory Report");
                Console.WriteLine("4. Add New Product");
                Console.WriteLine("5. Delete Product");
                var input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        Console.WriteLine("You have selected: Sell product.");
                        Console.WriteLine("This is your current product inventory: ");
                        foreach (var p in inventoryList)
                        {
                            Console.WriteLine(p);
                        }
                        Console.WriteLine("Which product would you like to sell and how many units?");
                        var productId = Int32.Parse(Console.ReadLine());
                        inventoryList.RemoveProduct(productId);
                        Console.WriteLine("Selected Product has been sold.");
                        break;
                    //case "2":
                    //    Console.WriteLine("You have selected: Stock Product.");

                    default:
                        break;
                }
            }




            //Console.WriteLine($"Your product costs {product._price} dollars, it has the id of {product._id} and quantity of {product._quantityOnHand}.");
        }
    }
}
