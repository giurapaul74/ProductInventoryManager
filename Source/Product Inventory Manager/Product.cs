using System;

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
                throw new ArgumentException("Can't sell amount greater than product quantity.");
            }
            else if (Quantity == 0)
            {
                throw new ArgumentException("No sellable stock available.");
            }
            else if (amount <= 0)
            {
                throw new ArgumentException("Can't sell 0 or less than product quantity.");
            }
            else
            {
                Quantity -= amount;
            }
        }

        public void StockProduct(int amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Can't add negative or 0 values to product.");
            }
            else
            {
                Quantity += amount;
            }
        }

        public void UpdatePrice(decimal newPrice)
        {
            if (newPrice <= 0)
            {
                throw new ArgumentException("Can't set product price to 0 or lower.");
            }
            else
            {
                Price = newPrice;
            }
        }

        public override string ToString()
        {
            return $"| ID #{Id} | {Name} | {Price:C} | {Quantity} item/s |";
        }
    }
}
