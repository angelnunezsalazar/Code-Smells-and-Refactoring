namespace MovieRental.ClassLibrary
{
    using System.Collections.Generic;

    public class Customer
    {
        public string Name { get; private set; }

        public double AmountOwed { get; private set; }

        public int FrequentRenterPoints { get; private set; }

        private List<Rental> rentals = new List<Rental>();

        public Customer(string name)
        {
            this.Name = name;
        }

        public void AddRental(Rental rental)
        {
            this.rentals.Add(rental);
        }

        public string Statement()
        {
            this.AmountOwed = 0;
            this.FrequentRenterPoints = 0;
            var result = this.Header();
            result += this.RentalLines();
            result += this.Footer();

            return result;
        }

        private string Header()
        {
            return "Rental Record for " + this.Name + "\n";
        }

        private string RentalLines()
        {
            string rentalLines = "";
            foreach (var rental in this.rentals)
                rentalLines += this.RentalLine(rental);
            return rentalLines;
        }

        private string RentalLine(Rental rental)
        {
            var rentalAmount = rental.AmountFor();
            this.AmountOwed += rentalAmount;
            this.FrequentRenterPoints += rental.FrecuentRenterPoints();

            return FormatRentaLine(rental, rentalAmount);
        }

        private static string FormatRentaLine(Rental rental, double rentalAmount)
        {
            return "\t" + rental.Movie.Title + "\t" + rentalAmount.ToString("0.0") + "\n";
        }

        private string Footer()
        {
            return "You owed " + this.AmountOwed.ToString("0.0") + "\n" + "You earned " + this.FrequentRenterPoints + " frequent renter points\n";
        }
    }
}
