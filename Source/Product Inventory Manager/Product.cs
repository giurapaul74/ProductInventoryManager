namespace Product_Inventory_Manager
{
    public class Product
    {
        public string _name { get; set; }
        public decimal _price { get; set; }
        public int _id { get; set; }
        public int _quantityOnHand { get; set; }

        public Product(string name, decimal price, int id, int quantityOnHand)
        {
            _name = name;
            _price = price;
            _id = id;
            _quantityOnHand = quantityOnHand;
        }

        public override string ToString()
        {
            return "Product ID #" + _id;
        }
    }
}
