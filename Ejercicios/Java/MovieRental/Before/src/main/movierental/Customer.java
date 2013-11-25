package movierental;

import java.util.ArrayList;
import java.util.List;

public class Customer {
	public String name;

	public double amountOwed;

	public int frequentRenterPoints;

	private List<Rental> rentals = new ArrayList<Rental>();

	public Customer(String name) {
		this.name = name;
	}

	public void AddRental(Rental rental) {
		this.rentals.add(rental);
	}

	public String Statement() {
		this.amountOwed = 0;
		this.frequentRenterPoints = 0;
		String result = "Rental Record for " + name + "\n";

		for (Rental rental : rentals) {
			double thisAmount = 0;

			// determine amounts for each line
			switch (rental.getMovie().getPriceCode()) {
			case Regular:
				thisAmount += 2;
				if (rental.getDaysRented() > 2)
					thisAmount += (rental.getDaysRented() - 2) * 1.5;
				break;
			case NewRelease:
				thisAmount += rental.getDaysRented() * 3;
				break;
			case Childrens:
				thisAmount += 1.5;
				if (rental.getDaysRented() > 3)
					thisAmount += (rental.getDaysRented() - 3) * 1.6;
				break;
			}
			// add frequent renter points
			this.frequentRenterPoints = this.frequentRenterPoints + 1;

			// add bonus for a two day new release rental
			if ((rental.getMovie().getPriceCode() == PriceCodes.NewRelease)
					&& rental.getDaysRented() > 1)
				this.frequentRenterPoints = this.frequentRenterPoints + 1;

			// show figures for this rental
			result += "\t" + rental.getMovie().getTitle() + "\t" + String.valueOf(thisAmount) + "\n";

			this.amountOwed = this.amountOwed + thisAmount;
		}

		// add footer lines
		result += "You owed " + String.valueOf(this.amountOwed) + "\n";
		result += "You earned " + this.frequentRenterPoints
				+ " frequent renter points\n";

		return result;
	}

}
