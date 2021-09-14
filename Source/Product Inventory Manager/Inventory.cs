using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Product_Inventory_Manager
{
    public class Inventory : IEnumerable<Product>
    {
        private Product _product;
        private Dictionary<int, Product> InventoryList { get; set; }

        public Inventory()
        {
            InventoryList = new Dictionary<int, Product>();
            _product = new Product();
        }

        public void AddProduct(int id, Product product)
        {
            InventoryList.Add(id, product);
        }

        public void RemoveProduct(int id)
        {
            InventoryList.Remove(id);
        }

        public void SellProductQuantity(int productId, int amount)
        {
            _product.Quantity -= amount;
        }

        public int UpdateProductQuantity(int productId)
        {
            if (!InventoryList.TryGetValue(productId, out Product product))
            {
                Console.WriteLine("Error. Product does not exist.");
            }

            return InventoryList[productId].Quantity;
        }

        public IEnumerator<Product> GetEnumerator() => InventoryList.Select(c => c.Value).GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
