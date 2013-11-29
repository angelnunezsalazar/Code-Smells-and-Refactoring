namespace MovieRental.ClassLibrary
{
    public class ChildrenPrice : IPrice
    {
        public double CalculatePrice(int daysRented)
        {
            double thisAmount = 1.5;
            if (daysRented > 3)
                thisAmount += (daysRented - 3) * 1.5;
            return thisAmount;
        }
    }
}