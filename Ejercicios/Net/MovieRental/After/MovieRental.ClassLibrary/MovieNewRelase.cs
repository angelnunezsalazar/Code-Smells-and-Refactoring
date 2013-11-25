namespace MovieRental.ClassLibrary
{
    public class MovieNewRelase : Movie
    {
        public MovieNewRelase(string title)
            : base(title, PriceCodes.NewRelease)
        {
        }

        public override double LineAmount(int daysRented)
        {
            return daysRented * 3;
        }
    }
}