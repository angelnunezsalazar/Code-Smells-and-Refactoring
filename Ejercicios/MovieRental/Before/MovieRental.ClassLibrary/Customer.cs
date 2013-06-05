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
            string result = "Rental Record for " + Name + "\n";

            foreach (var rental in this.rentals)
            {
                double thisAmount = 0;

                //determine amounts for each line
                switch (rental.Movie.PriceCode)
                {
                    case Movie.PriceCodes.Regular:
                        thisAmount += 2;
                        if (rental.DaysRented > 2)
                            thisAmount += (rental.DaysRented - 2) * 1.5;
                        break;
                    case Movie.PriceCodes.NewRelease:
                        thisAmount += rental.DaysRented * 3;
                        break;
                    case Movie.PriceCodes.Childrens:
                        thisAmount += 1.5;
                        if (rental.DaysRented > 3)
                            thisAmount += (rental.DaysRented - 3) * 1.5;
                        break;
                }
                // add frequent renter points
                this.FrequentRenterPoints = this.FrequentRenterPoints + 1;

                // add bonus for a two day new release rental
                if ((rental.Movie.PriceCode == Movie.PriceCodes.NewRelease) && rental.DaysRented > 1)
                    this.FrequentRenterPoints = this.FrequentRenterPoints + 1;

                //show figures for this rental
                result += "\t" + rental.Movie.Title + "\t" + thisAmount.ToString("0.0") + "\n";

                this.AmountOwed = this.AmountOwed + thisAmount;
            }

            //add footer lines
            result += "You owed " + this.AmountOwed.ToString("0.0") + "\n";
            result += "You earned " + this.FrequentRenterPoints + " frequent renter points\n";

            return result;
        }
    }
}
