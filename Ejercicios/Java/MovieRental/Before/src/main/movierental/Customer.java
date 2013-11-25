package movierental;

import java.util.ArrayList;
import java.util.List;

public class Customer
{
    public String name;

    public double amountOwed;

    public int frequentRenterPoints;

    private List<Rental> rentals = new ArrayList<Rental>();

    public Customer(String name)
    {
        this.name = name;
    }

    public void AddRental(Rental rental)
    {
        this.rentals.add(rental);
    }

    public String Statement()
    {
        this.amountOwed = 0;
        this.frequentRenterPoints = 0;
        String result = "Rental Record for " + name + "\n";

        for (Rental rental : rentals) {
        {
            double thisAmount = 0;

            //determine amounts for each line
            switch (rental.getMovie())
            {
                case Movie.PriceCodes.Regular:
                    thisAmount += 2;
                    if (rental.DaysRented > 2)
                        thisAmount += (rental.DaysRented - 2) * 1.5;
                    break;
                case Movie.PriceCodes.NewRelease:
                    thisAmount += rental.DaysRented * 3;
                    break;
                case Movie.PriceCodes.Childrens:
                    thisAmount += 1.5;
                    if (rental.DaysRented > 3)
                        thisAmount += (rental.DaysRented - 3) * 1.5;
                    break;
            }
            // add frequent renter points
            this.frequentRenterPoints = this.frequentRenterPoints + 1;

            // add bonus for a two day new release rental
            if ((rental.Movie.PriceCode == Movie.PriceCodes.NewRelease) && rental.DaysRented > 1)
                this.frequentRenterPoints = this.frequentRenterPoints + 1;

            //show figures for this rental
            result += "\t" + rental.Movie.Title + "\t" + thisAmount.ToString("0.0") + "\n";

            this.amountOwed = this.amountOwed + thisAmount;
        }

        //add footer lines
        result += "You owed " + this.amountOwed.ToString("0.0") + "\n";
        result += "You earned " + this.frequentRenterPoints + " frequent renter points\n";

        return result;
    }
}
