using System;
using System.Collections.Generic;

namespace Product_Inventory_Manager
{
    public class Inventory
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
    }
}
