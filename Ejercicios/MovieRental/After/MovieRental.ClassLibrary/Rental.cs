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
    }
}
