namespace Assignment4
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int UnitPrice { get; set; } //Might need to be some other type to allow for 4.99
        public string QuantityPerUnit { get; set; }
        public int UnitsInStock { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }

    }
}
