namespace MovieRental.Tests
{
    using System;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using MovieRental.ClassLibrary;

    [TestClass]
    public class CustomerTests
    {
        [TestMethod]
        public void Statement()
        {
            var customer = new Customer("John Stevens");

            var movie1 = new Movie("Cinderella", PriceCodes.Childrens);
            var movie2 = new Movie("Star Wars", PriceCodes.Regular);
            var movie3 = new Movie("Gladiator", PriceCodes.NewRelease);

            customer.AddRental(new Rental(movie1, 5));
            customer.AddRental(new Rental(movie2, 5));
            customer.AddRental(new Rental(movie3, 5));

            var statement = customer.Statement();

            var expected = "<rentalrecord>" +
                           "<client>John Stevens</client>" +
                           "<movies>" +
                           "<movie amount='3'>Cinderella</movie>" +
                           "<movie amount='6.5'>Star Wars</movie>" +
                           "<movie amount='15'>Gladiator</movie>" +
                           "</movies>" +
                           "<total>24.5</total>" +
                           "<points>4</points>" +
                           "</rentalrecord>";
            Assert.AreEqual(expected, statement);
        }
    }
}
