namespace MovieRental.ClassLibrary
{
    public class Rental
    {
        public int DaysRented { get; private set; }

        public Movie Movie { get; private set; }

        public Rental(Movie movie, int daysRented)
        {
            this.Movie = movie;
            this.DaysRented = daysRented;
        }

        public double LineAmount()
        {
            return this.Movie.LineAmount(DaysRented);
        }

        public int CalculateFrecuentPoints()
        {
            var frequentRenterPoints = 1;
            var bonusForTwoDayRental = (Movie.PriceCode == Movie.PriceCodes.NewRelease) && DaysRented > 1;
            if (bonusForTwoDayRental)
                frequentRenterPoints = 2;
            return frequentRenterPoints;
        }
    }
}
