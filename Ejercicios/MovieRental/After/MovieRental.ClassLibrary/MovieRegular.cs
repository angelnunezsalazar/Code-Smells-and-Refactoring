namespace MovieRental.ClassLibrary
{
    public class MovieRegular : Movie
    {
        public MovieRegular(string title)
            : base(title, PriceCodes.Regular)
        {
        }

        public override double LineAmount(int daysRented)
        {
            double lineAmount = 2;
            if (daysRented > 2)
                lineAmount += (daysRented - 2) * 1.5;
            return lineAmount;
        }
    }
}