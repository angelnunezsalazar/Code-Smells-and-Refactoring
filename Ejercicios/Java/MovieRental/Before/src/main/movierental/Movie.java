package movierental;

public class Movie
{
    private PriceCodes priceCode;

    private String title;

    public Movie(String title, PriceCodes priceCode)
    {
        this.title = title;
        this.setPriceCode(priceCode);
    }

	public PriceCodes getPriceCode() {
		return priceCode;
	}

	public void setPriceCode(PriceCodes priceCode) {
		this.priceCode = priceCode;
	}
}