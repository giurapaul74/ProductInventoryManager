using System;
using System.Collections.Generic;

namespace Product_Inventory_Manager
{
    class Program
    {
        static void Main(string[] args)
        {

            var inventoryList = _inventoryList;
            //var prod = _product;
            //var product = new Product("Stool", 65m, 1, 2);
            //var product2 = new Product("Bench", 125m, 2, 3);
            //var product3 = new Product("Wrench", 30m, 3, 5);
            //var product4 = new Product("Tire Iron", 36m, 4, 3);
            //var product5 = new Product("Adjustable Wrench", 40m, 5, 4);

            //inventoryList.AddProduct(product);
            //inventoryList.AddProduct(product2);
            //inventoryList.AddProduct(product3);
            //inventoryList.AddProduct(product4);
            //inventoryList.AddProduct(product5);

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
                Console.WriteLine("6. Update Product Price");
                Console.WriteLine("7. Exit");
                var input = Console.ReadLine();

                if (input == "7")
                {
                    Console.WriteLine("Exiting...");
                    break;
                }

                switch (input)
                {
                    case "1":
                        SellProduct();
                        break;
                    case "2":
                        StockProduct();
                        break;
                    case "3":
                        ShowReport();
                        break;
                    case "4":
                        AddNewProduct();
                        break;
                    case "5":
                        DeleteProduct();
                        break;
                    case "6":
                        UpdatePrice();
                        break;
                    default:
                        break;
                }
            }
        }

        public static Inventory _inventoryList = new Inventory();
        public static Product _product = new Product();

        public static void UpdatePrice()
        {
            Console.WriteLine("You have selected: Update Product Price.");
            Console.WriteLine("This is your inventory: ");
            foreach (var item in _inventoryList)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("Select a product: ");
            var productId = int.Parse(Console.ReadLine());
            var product = _inventoryList.GetProduct(productId);
            Console.WriteLine("Product selected.");
            Console.WriteLine("You can update the product's price now.");
            var newPrice = decimal.Parse(Console.ReadLine());
            var updatedPrice = product.UpdatePrice(newPrice);
            Console.WriteLine("Price Updated.");
        }

        public static void DeleteProduct()
        {
            Console.WriteLine("You have selected: Delete Product.");
            Console.WriteLine("This is your inventory: ");
            foreach (var item in _inventoryList)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
            Console.WriteLine("Which product would you like to delete from inventory?");
            var productId = Int32.Parse(Console.ReadLine());
            //var product = _inventoryList.GetProduct(productId);
            _inventoryList.RemoveProduct(productId);
            Console.WriteLine($"Product {productId} removed from inventory.");
        }

        public static void AddNewProduct()
        {
            Console.WriteLine("You have selected: Add New Product.");
            Console.WriteLine("This is your inventory: ");
            foreach (var item in _inventoryList)
            {
                Console.WriteLine(item);
            }
            //Console.WriteLine("Please enter a product name: ");
            //_product.Name = Console.ReadLine();
            Prompt.ReadString("Enter product name:", value => _product.Name = value);
            //Console.WriteLine("Please enter a product price: ");
            Prompt.ReadDecimal("Enter a price:", value => _product.Price = value);
            Prompt.ReadInt("Enter an Id:", value => _product.Id = value);
            var product = new Product(_product.Name, _product.Price, _product.Id, _product.Quantity);
            _inventoryList.AddProduct(product);
            Console.WriteLine($"{product} added to Inventory.");
        }

        public static void ShowReport()
        {
            Console.WriteLine("You have selected: Product Inventory Report.");
            Console.WriteLine();
            decimal total = 0;
            if (_inventoryList.InventoryList.Count == 0)
            {
                Console.WriteLine("There are no products available for showing.");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("This is your current inventory: ");
                Console.WriteLine("| ID | Name              | Price   | Qty | Value     |");
                Console.WriteLine("------------------------------------------------------");
                foreach (var item in _inventoryList)
                {
                    var productSumPerQuantity = item.Quantity * item.Price;
                    Console.WriteLine($"| {item.Id,-2} | {item.Name,-17} | {item.Price,7:C} | {item.Quantity,-3} | {productSumPerQuantity,9:C} |");
                    total += productSumPerQuantity;
                }
                Console.WriteLine();
                Console.WriteLine($"Total inventory: {total:C}");
                Console.WriteLine();
            }
        }

        public static void StockProduct()
        {
            Console.WriteLine("You have selected: Stock Product.");
            Console.WriteLine("This is your current product inventory: ");
            foreach (var items in _inventoryList)
            {
                Console.WriteLine(items);
            }
            Console.WriteLine("Which product would you like to add stock to?");
            var productid = Int32.Parse(Console.ReadLine());
            var pr = _inventoryList.GetProduct(productid);
            Console.WriteLine("How many units would you like to add?");
            var stockAddAmount = Int32.Parse(Console.ReadLine());
            pr.StockProduct(stockAddAmount);
            Console.WriteLine($"Added {stockAddAmount} items to product of type {pr.Name}");
        }

        public static void SellProduct()
        {
            Console.WriteLine("You have selected: Sell product.");
            Console.WriteLine("This is your current product inventory: ");
            foreach (var p in _inventoryList)
            {
                Console.WriteLine(p);
            }
            Console.WriteLine("Which product would you like to sell?");
            var productId = Int32.Parse(Console.ReadLine());
            var prod = _inventoryList.GetProduct(productId);
            Console.WriteLine("How many units would you like to sell?");
            var quantityToSell = Int32.Parse(Console.ReadLine());
            prod.SellProduct(quantityToSell);
            Console.WriteLine($"Sold {quantityToSell} items of type {prod.Name}.");
        }
    }
}
