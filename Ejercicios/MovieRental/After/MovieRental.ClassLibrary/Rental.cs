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

        public double AmountFor()
        {
            double thisAmount = 0;
            switch (Movie.PriceCode)
            {
                case PriceCodes.Regular:
                    thisAmount += 2;
                    if (DaysRented > 2)
                    {
                        thisAmount += (DaysRented - 2) * 1.5;
                    }
                    break;
                case PriceCodes.NewRelease:
                    thisAmount += DaysRented * 3;
                    break;
                case PriceCodes.Childrens:
                    thisAmount += 1.5;
                    if (DaysRented > 3)
                    {
                        thisAmount += (DaysRented - 3) * 1.5;
                    }
                    break;
            }
            return thisAmount;
        }

        public int FrecuentRenterPoints()
        {
            var bonuesIsEarned = (Movie.PriceCode == PriceCodes.NewRelease) && DaysRented > 1;
            if (bonuesIsEarned)
                return 2;
            return 1;
        }
    }
}
