using System;

namespace Product_Inventory_Manager
{
    class Program
    {
        static void Main(string[] args)
        {
            var inventoryList = new Inventory();
            var product = new Product("Stool", 65m, 1, 1);
            var product2 = new Product("Bench", 125m, 2, 3);

            inventoryList.AddProduct(1, product);
            inventoryList.AddProduct(2, product2);

            foreach (var p in inventoryList)
            {
                Console.WriteLine(p);
            }

            //Console.WriteLine($"Your product costs {product._price} dollars, it has the id of {product._id} and quantity of {product._quantityOnHand}.");
        }
    }
}
