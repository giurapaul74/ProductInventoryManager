using System;
using System.Collections.Generic;

namespace Product_Inventory_Manager
{
    class Program
    {
        private static Inventory _inventoryList = new Inventory();

        static void Main(string[] args)
        {

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
                Console.WriteLine("7. Clear Product Inventory");
                Console.WriteLine("8. Exit.");
                var input = Console.ReadLine();

                if (input == "8")
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
                    case "7":
                        ClearProductInventory();
                        break;
                    default:
                        break;
                }
            }
        }

        public static void UpdatePrice()
        {
            Console.WriteLine("You have selected: Update Product Price.");
            Console.WriteLine("This is your inventory: ");
            ShowReport();
            try
            {
                Console.WriteLine("Select a product: ");
                var productId = int.Parse(Console.ReadLine());
                var product = _inventoryList.GetProduct(productId);
                Console.WriteLine("Product selected.");
                Console.WriteLine("You can update the product's price now.");
                var newPrice = decimal.Parse(Console.ReadLine());
                product.UpdatePrice(newPrice);
                Console.WriteLine("Product price updated successfully.");
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Invalid decimal value.", ex);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Invalid value.", ex);
            }
        }

        public static void DeleteProduct()
        {
            Console.WriteLine("You have selected: Delete Product.");
            Console.WriteLine("This is your inventory: ");
            ShowReport();
            try
            {
                Console.WriteLine();
                Console.WriteLine("Which product would you like to delete from inventory?");
                var productId = Int32.Parse(Console.ReadLine());
                _inventoryList.RemoveProduct(productId);
                Console.WriteLine($"Successfully removed product {productId} from inventory.");
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Invalid int value.", ex);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Invalid value.", ex);
            }
        }

        public static void AddNewProduct()
        {
            Console.WriteLine("You have selected: Add New Product.");
            Console.WriteLine("This is your inventory: ");
            ShowReport();
            var product = new Product();
            Prompt.ReadString("Enter product name:", value => product.Name = value);
            Prompt.ReadDecimal("Enter a price:", value => product.Price = value);
            Prompt.ReadInt("Enter an Id:", value =>
            {
                if (_inventoryList.InventoryList.ContainsKey(value))
                {
                    throw new ArgumentException("A product with this ID already exists.");
                }

                product.Id = value;
            });
            try
            {
                _inventoryList.AddProduct(product);
                Console.WriteLine($"{product} has been added to inventory.");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Failed to add product to inventory.", ex);
            }

        }

        public static void ShowReport()
        {
            Console.WriteLine();
            decimal total = 0;
            if (_inventoryList.InventoryList.Count == 0)
            {
                Console.WriteLine("There are no products available for showing.");
                Console.WriteLine();
                return;
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
            ShowReport();
            if (_inventoryList.InventoryList.Count >= 1)
            {
                try
                {
                    Console.WriteLine("Which product would you like to add stock to?");
                    var productid = Int32.Parse(Console.ReadLine());
                    var pr = _inventoryList.GetProduct(productid);
                    Console.WriteLine("How many units would you like to add?");
                    var stockAddAmount = Int32.Parse(Console.ReadLine());
                    pr.StockProduct(stockAddAmount);
                    Console.WriteLine($"Successfully added stock to {pr}.");
                }
                catch (FormatException ex)
                {
                    Console.WriteLine("Invalid value. Enter an int instead.", ex);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Invalid value.", ex);
                }
            }
        }

        public static void SellProduct()
        {
            Console.WriteLine("You have selected: Sell product.");
            Console.WriteLine("This is your current product inventory: ");
            ShowReport();
            if (_inventoryList.InventoryList.Count >= 1)
            {
                try
                {
                    Console.WriteLine("Which product would you like to sell?");
                    var productId = Int32.Parse(Console.ReadLine());
                    var prod = _inventoryList.GetProduct(productId);
                    Console.WriteLine("How many units would you like to sell?");
                    var quantityToSell = Int32.Parse(Console.ReadLine());
                    prod.SellProduct(quantityToSell);
                    Console.WriteLine($"Successfully sold {quantityToSell} unit/s of {prod}.");
                }
                catch (FormatException ex)
                {
                    Console.WriteLine("Error. Enter an int value.", ex);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Invalid value.", ex);
                }
            }
        }

        public static void ClearProductInventory()
        {
            Console.WriteLine("You have selected: Clear Product Inventory.");
            Console.WriteLine("This is your inventory.");
            ShowReport();
            var result = Prompt.ReadBool("Would you like to clear your inventory");

            if (result)
            {
                if (_inventoryList.InventoryList.Count == 0)
                {
                    Console.WriteLine("Your inventory is already empty. Cannot clear empty inventory.");
                    return;
                }

                _inventoryList.DeleteInventory();
                Console.WriteLine("Inventory cleared successfully.");
            }
            else
            {
                Console.WriteLine("Operation cancelled.");
            }
        }
    }
}
