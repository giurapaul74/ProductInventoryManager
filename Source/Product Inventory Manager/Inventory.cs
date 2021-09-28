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
            InventoryList.Add(product.Id, product);
        }

        public void RemoveProduct(int id)
        {
            InventoryList.Remove(id);
        }

        public Product GetProduct(int productId)
        {
            if (!InventoryList.TryGetValue(productId, out Product product))
            {
                throw new KeyNotFoundException("Product ID not found.");
            }

            return product;
        }

        public IEnumerator<Product> GetEnumerator() => InventoryList.Select(c => c.Value).GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
