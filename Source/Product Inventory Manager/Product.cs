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
            Quantity -= amount;
        }

        public void StockProduct(int amount)
        {
            Quantity += amount;
        }

        public decimal UpdatePrice(decimal newPrice)
        {
            return Price = newPrice;
        }

        public override string ToString()
        {
            return $"| ID #{Id} | {Name} | {Price:C} | {Quantity} item/s |";
        }
    }
}
