namespace MovieRental.ClassLibrary
{
    using System.Collections.Generic;
    using System.Text;

    public class Customer
    {
        private List<Rental> rentals = new List<Rental>();

        public Customer(string name)
        {
            this.Name = name;
        }

        public string Name { get; private set; }

        public void AddRental(Rental rental)
        {
            this.rentals.Add(rental);
        }

        public string Statement()
        {
            StringBuilder statement=new StringBuilder();

            statement.Append("<rentalrecord>");
            statement.Append("<client>" + this.Name+"</client>");
            statement.Append("<movies>");

            double totalAmount = 0;
            int frequentRenterPoints = 0;
            foreach (var rental in rentals)
            {
                double thisAmount = 0;

                // Determine amounts for each line
                switch (rental.Movie.PriceCode)
                {
                    case PriceCodes.Regular:
                        thisAmount += 2;
                        if (rental.DaysRented > 2)
                        {
                            thisAmount += (rental.DaysRented - 2) * 1.5;
                        }
                        break;

                    case PriceCodes.NewRelease:
                        thisAmount += rental.DaysRented * 3;
                        break;

                    case PriceCodes.Childrens:
                        thisAmount += 1.5;
                        if (rental.DaysRented > 3)
                        {
                            thisAmount = (rental.DaysRented - 3) * 1.5;
                        }
                        break;
                }

                // Add frequent renter points
                frequentRenterPoints++;

                // Add bonus for a two-day new-release rental
                if ((rental.Movie.PriceCode == PriceCodes.NewRelease) && (rental.DaysRented > 1)) 
                    frequentRenterPoints++;

                totalAmount += thisAmount;

                // Show figures for this rental
                statement.Append("<movie amount='" + thisAmount + "'>");
                statement.Append(rental.Movie.Title);
                statement.Append("</movie>");
            }
            statement.Append("</movies>");


            // Add footer lines
            statement.Append("<total>" + totalAmount + "</total>");
            statement.Append("<points>" + frequentRenterPoints + "</points>");

            statement.Append("</rentalrecord>");
            return statement.ToString();
        }
    }
}
