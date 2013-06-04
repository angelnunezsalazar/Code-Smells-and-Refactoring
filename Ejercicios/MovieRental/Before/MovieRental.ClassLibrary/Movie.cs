namespace MovieRental.ClassLibrary
{
    public enum PriceCodes
    {
        Regular,
        NewRelease,
        Childrens
    }
    public class Movie
    {
        public PriceCodes PriceCode { get; set; }

        public string Title { get; private set; }

        public Movie(string title, PriceCodes priceCode)
        {
            this.Title = title;
            this.PriceCode = priceCode;
        }
    }
}
