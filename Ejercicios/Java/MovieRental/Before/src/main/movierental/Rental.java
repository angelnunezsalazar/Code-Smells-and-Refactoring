package movierental;

public class Rental
{
	private int daysRented;
	private Movie movie;

    public Rental(Movie movie, int daysRented)
    {
        this.setMovie(movie);
        this.setDaysRented(daysRented);
    }

	public int getDaysRented() {
		return daysRented;
	}

	public void setDaysRented(int daysRented) {
		this.daysRented = daysRented;
	}

	public Movie getMovie() {
		return movie;
	}

	public void setMovie(Movie movie) {
		this.movie = movie;
	}
}