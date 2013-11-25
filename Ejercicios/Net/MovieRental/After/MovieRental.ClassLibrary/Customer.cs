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
            result += this.CalculateRental();
            result += this.Footer();

            return result;
        }

        private string Header()
        {
            return "Rental Record for " + this.Name + "\n";
        }

        private string CalculateRental()
        {
            string result = "";
            foreach (var rental in this.rentals)
            {
                var thisAmount = rental.LineAmount();
                this.FrequentRenterPoints += rental.CalculateFrecuentPoints();
                this.AmountOwed = this.AmountOwed + thisAmount;

                result += FormatLine(rental, thisAmount);
            }
            return result;
        }

        private string Footer()
        {
            return "You owed " + this.AmountOwed.ToString("0.0") + "\n" + "You earned " + this.FrequentRenterPoints + " frequent renter points\n";
        }

        private static string FormatLine(Rental rental, double thisAmount)
        {
            return "\t" + rental.Movie.Title + "\t" + thisAmount.ToString("0.0") + "\n";
        }
    }
}
