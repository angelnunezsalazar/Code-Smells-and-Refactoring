namespace MovieRental.ClassLibrary
{
    public class ReleasePrice : IPrice
    {
        public double CalculatePrice(int daysRented)
        {
            return daysRented * 3;
        }
    }
}