namespace After
{
    public class Product
    {
        public string Name { get; private set; }

        public decimal UnitPrice { get; private set; }

        public Category Category { get; private set; }

        public int UnitsInStock { get; set; }

        public string Image { get; private set; }

        private XmlProductSerializer xmlProductSerializer = new XmlProductSerializer();

        public Product(string name, decimal unitPrice, Category category, string image)
        {
            this.Name = name;
            this.UnitPrice = unitPrice;
            this.Category = category;
            this.Image = image;
        }

        public string ToXml()
        {
            return this.xmlProductSerializer.ToXml(this);
        }
    }
}