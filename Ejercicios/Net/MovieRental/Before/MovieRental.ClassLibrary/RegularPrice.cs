namespace MovieRental.ClassLibrary
{
    public class RegularPrice : IPrice
    {
        public double CalculatePrice(int daysRented)
        {
            double thisAmount = 2;
            if (daysRented > 2)
                thisAmount += (daysRented - 2) * 1.5;
            return thisAmount;
        }
    }
}