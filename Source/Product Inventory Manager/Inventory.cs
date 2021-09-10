using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Product_Inventory_Manager
{
    public class Inventory : IEnumerable<Product>
    {
        private Dictionary<int, Product> InventoryList { get; set; }

        public Inventory()
        {
            InventoryList = new Dictionary<int, Product>();
        }

        public void AddProduct(int id, Product product)
        {
            InventoryList.Add(id, product);
        }

        public void RemoveProduct(int id)
        {
            InventoryList.Remove(id);
        }

        public void SellProduct(int id, int quantity)
        {
            //InventoryList.Remove(id, out quantity);
        }

        public IEnumerator<Product> GetEnumerator() => InventoryList.Select(c => c.Value).GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
