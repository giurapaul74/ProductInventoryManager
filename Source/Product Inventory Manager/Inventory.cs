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
            }
        }

        public void RemoveProduct(int id)
        {
            if (!InventoryList.ContainsKey(id))
            {
                throw new ArgumentException("This product doesn't exist in inventory.");
            }
            else
            {
                InventoryList.Remove(id);
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

        public void DeleteInventory()
        {
            InventoryList.Clear();
        }

        public IEnumerator<Product> GetEnumerator() => InventoryList.Values.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
