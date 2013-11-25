namespace After.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using After;

    [TestClass]
    public class ProductTests
    {
        [TestMethod]
        public void SerializeToXml()
        {
            Product product = CreateProduct();

            string xml = product.ToXml();

            Assert.AreEqual("<product><name>Black Bike</name><category>Bikes</category></product>", xml);
        }

        private Product CreateProduct()
        {
            return new Product("Black Bike", 250, Category.Bikes, "Bike01.jpg");
        }
    }
}