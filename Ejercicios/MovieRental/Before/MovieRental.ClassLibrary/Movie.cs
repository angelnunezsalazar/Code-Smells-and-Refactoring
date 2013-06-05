namespace MovieRental.ClassLibrary
{
    public class Movie
    {
        public enum PriceCodes
        {
            Regular,
            NewRelease,
            Childrens
        }

        public PriceCodes PriceCode { get; set; }

        public string Title { get; private set; }

        public Movie(string title, PriceCodes priceCode)
        {
            this.Title = title;
            this.PriceCode = priceCode;
        }
    }
}
