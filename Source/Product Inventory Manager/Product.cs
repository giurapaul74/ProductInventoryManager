namespace Product_Inventory_Manager
{
    public class Product
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Id { get; set; }
        public int Quantity { get; set; }

        public Product(string name, decimal price, int id, int quantity)
        {
            Name = name;
            Price = price;
            Id = id;
            Quantity = quantity;
        }

        public override string ToString()
        {
            return $"Product {Id} : {Name} : {Price} dollars : {Quantity} item/s";
        }
    }
}
