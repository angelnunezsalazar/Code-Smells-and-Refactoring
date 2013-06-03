using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ManualRefactoring.Tests
{
    using System.IO;

    using ManualRefactoring.ClassLibrary;

    [TestClass]
    public class CustomerTests
    {
        private StringWriter sw;

        [TestInitialize]
        public void Setup()
        {
            this.sw = new StringWriter();
            Console.SetOut(this.sw);
        }

        [TestMethod]
        public void PrintOwingTest()
        {
            var customer = new Customer { Name = "John Perez" };
            customer.Orders.Add(new Order { Amount = 120.50m });
            customer.Orders.Add(new Order { Amount = 60.30m });

            customer.PrintOwing();

            string expectedPrinting = "**************************\r\n***** Customer Owes ******\r\n**************************\r\nName:John Perez\r\nAmount:180.80\r\n";
            Assert.AreEqual(expectedPrinting, this.sw.ToString());
        }

        [TestCleanup]
        public void TearDown()
        {
            this.sw.Dispose();
        }
    }
}
