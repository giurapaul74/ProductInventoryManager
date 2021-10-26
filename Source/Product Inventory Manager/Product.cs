namespace Product_Inventory_Manager
{
    public class Product
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Id { get; set; }
        public int Quantity { get; private set; }

        public Product()
        {

        }

        public Product(string name, decimal price, int id, int quantity)
        {
            Name = name;
            Price = price;
            Id = id;
            Quantity = quantity;
        }

        public void SellProduct(int amount)
        {
            if (amount > Quantity)
            {
                Logger.LogMessage("Operation failed. Amount to sell greater than product quantity.");
                return;
            }
            else if (Quantity == 0)
            {
                Logger.LogMessage("No sellable stock available for this product.");
                return;
            }
            else if (amount <= 0)
            {
                Logger.LogMessage("Error. Cannot sell quantity lesser than or equal to 0.");
                return;
            }
            else
            {
                Quantity -= amount;
                Logger.LogMessage($"Sold {amount} items of type {Name}.");
            }
        }

        public void StockProduct(int amount)
        {
            if (amount <= 0)
            {
                Logger.LogMessage("Error. Cannot add negative or 0 values to product.");
                return;
            }
            else
            {
                Quantity += amount;
                Logger.LogMessage($"Added {amount} items to product {Name}.");
            }
        }

        public void UpdatePrice(decimal newPrice)
        {
            if (newPrice <= 0)
            {
                Logger.LogMessage("Cannot set product price to 0 or lower*. Try again.");
                Logger.LogMessage("");
            }
            else
            {
                Price = newPrice;
                Logger.LogMessage("Price Updated.");
            }
        }

        public override string ToString()
        {
            return $"| ID #{Id} | {Name} | {Price:C} | {Quantity} item/s |";
        }
    }
}
