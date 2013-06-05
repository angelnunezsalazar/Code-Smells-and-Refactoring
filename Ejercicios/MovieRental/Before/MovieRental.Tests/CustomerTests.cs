namespace MovieRental.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using MovieRental.ClassLibrary;

    [TestClass]
    public class CustomerTests
    {
        private Customer customer;
        private Movie newRelease1;
        private Movie newRelease2;
        private Movie childrens;
        private Movie regular1;
        private Movie regular2;
        private Movie regular3;

        [TestInitialize]
        public void SetUp()
        {
            customer = new Customer("Customer Name");
            newRelease1 = new Movie("New Release 1", Movie.PriceCodes.NewRelease);
            newRelease2 = new Movie("New Release 2", Movie.PriceCodes.NewRelease);
            childrens = new Movie("Childrens", Movie.PriceCodes.Childrens);
            regular1 = new Movie("Regular 1", Movie.PriceCodes.Regular);
            regular2 = new Movie("Regular 2", Movie.PriceCodes.Regular);
            regular3 = new Movie("Regular 3", Movie.PriceCodes.Regular);
        }

        [TestMethod]
        public void SingleNewRelease()
        {
            customer.AddRental(new Rental(newRelease1, 3));
            customer.Statement();
            AssertAmountAndPointsForReport(9.0, 2);
        }

        [TestMethod]
        public void DualNewRelease()
        {
            customer.AddRental(new Rental(newRelease1, 3));
            customer.AddRental(new Rental(newRelease2, 3));
            customer.Statement();
            AssertAmountAndPointsForReport(18.0, 4);
        }

        [TestMethod]
        public void SingleChildrens()
        {
            customer.AddRental(new Rental(childrens, 3));
            customer.Statement();
            AssertAmountAndPointsForReport(1.5, 1);
        }

        [TestMethod]
        public void MultipleRegular()
        {
            customer.AddRental(new Rental(regular1, 1));
            customer.AddRental(new Rental(regular2, 2));
            customer.AddRental(new Rental(regular3, 3));
            customer.Statement();
            AssertAmountAndPointsForReport(7.5, 3);
        }

        [TestMethod]
        public void StatementFormat()
        {
            customer.AddRental(new Rental(regular1, 1));
            customer.AddRental(new Rental(regular2, 2));
            customer.AddRental(new Rental(regular3, 3));

            Assert.AreEqual(
              "Rental Record for Customer Name\n" +
                "\tRegular 1\t2.0\n" +
                "\tRegular 2\t2.0\n" +
                "\tRegular 3\t3.5\n" +
                "You owed 7.5\n" +
                "You earned 3 frequent renter points\n",
              customer.Statement());
        }

        private void AssertAmountAndPointsForReport(double expectedAmount, int expectedPoints)
        {
            Assert.AreEqual(expectedAmount, this.customer.AmountOwed);
            Assert.AreEqual(expectedPoints, this.customer.FrequentRenterPoints);
        }
    }
}
