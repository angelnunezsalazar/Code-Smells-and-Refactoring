namespace MovieRental.ClassLibrary
{
    public class MovieChildren : Movie
    {
        public MovieChildren(string title)
            : base(title, PriceCodes.Childrens)
        {
        }

        public override double LineAmount(int daysRented)
        {
            double lineAmount = 1.5;
            if (daysRented > 3) 
                lineAmount += (daysRented - 3) * 1.5;
            return lineAmount;
        }
    }
}