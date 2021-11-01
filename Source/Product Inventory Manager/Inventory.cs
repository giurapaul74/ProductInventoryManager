using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Product_Inventory_Manager
{
    public class Inventory : IEnumerable<Product>
    {
        public Dictionary<int, Product> InventoryList { get; set; }

        public Inventory()
        {
            InventoryList = new Dictionary<int, Product>();
        }

        public void AddProduct(Product product)
        {
            if (InventoryList.ContainsKey(product.Id))
            {
                throw new ArgumentException("Another product with this ID already exists.");
            }
            else
            {
                InventoryList.Add(product.Id, product);
                Logger.LogMessage($"{product} added to inventory.");
            }
        }

        public void RemoveProduct(int id)
        {
            if (!InventoryList.ContainsKey(id))
            {
                Logger.LogMessage("Cannot remove product. Id doesn't exist in inventory.");
                return;
            }
            else
            {
                InventoryList.Remove(id);
                Logger.LogMessage($"Successfully removed product {id} from inventory.");
            }
        }

        public Product GetProduct(int productId)
        {
            try
            {
                InventoryList.TryGetValue(productId, out Product product);
                return product;
            }   
            catch (KeyNotFoundException ex)
            {
                Console.WriteLine("Product Id not found.", ex);
                throw;
            }

            
        }

        public IEnumerator<Product> GetEnumerator() => InventoryList.Values.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
