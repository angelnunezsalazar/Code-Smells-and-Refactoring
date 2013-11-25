package movierental;

import org.junit.Assert;
import org.junit.Before;
import org.junit.Test;
import static org.junit.Assert.*;

public class CustomerTest {
	private Customer customer;
    private Movie newRelease1;
    private Movie newRelease2;
    private Movie childrens;
    private Movie regular1;
    private Movie regular2;
    private Movie regular3;

    @Before
    public void SetUp()
    {
        customer = new Customer("Customer Name");
        newRelease1 = new Movie("New Release 1", PriceCodes.NewRelease);
        newRelease2 = new Movie("New Release 2", PriceCodes.NewRelease);
        childrens = new Movie("Childrens", PriceCodes.Childrens);
        regular1 = new Movie("Regular 1", PriceCodes.Regular);
        regular2 = new Movie("Regular 2", PriceCodes.Regular);
        regular3 = new Movie("Regular 3", PriceCodes.Regular);
    }

    @Test
    public void SingleNewRelease()
    {
        customer.AddRental(new Rental(newRelease1, 3));
        customer.Statement();
        AssertAmountAndPointsForReport(9.0, 2);
    }

    @Test
    public void DualNewRelease()
    {
        customer.AddRental(new Rental(newRelease1, 3));
        customer.AddRental(new Rental(newRelease2, 3));
        customer.Statement();
        AssertAmountAndPointsForReport(18.0, 4);
    }

    @Test
    public void SingleChildrens()
    {
        customer.AddRental(new Rental(childrens, 3));
        customer.Statement();
        AssertAmountAndPointsForReport(1.5, 1);
    }

    @Test
    public void MultipleRegular()
    {
        customer.AddRental(new Rental(regular1, 1));
        customer.AddRental(new Rental(regular2, 2));
        customer.AddRental(new Rental(regular3, 3));
        customer.Statement();
        AssertAmountAndPointsForReport(7.5, 3);
    }

    @Test
    public void StatementFormat()
    {
        customer.AddRental(new Rental(regular1, 1));
        customer.AddRental(new Rental(regular2, 2));
        customer.AddRental(new Rental(regular3, 3));

        assertEquals(
          "Rental Record for Customer Name\n" +
            "\tRegular 1\t2.0\n" +
            "\tRegular 2\t2.0\n" +
            "\tRegular 3\t3.5\n" +
            "You owed 7.5\n" +
            "You earned 3 frequent renter points\n",
          customer.Statement());
    }

    private void AssertAmountAndPointsForReport(double expectedAmount, int expectedPoints)
    {
    	assertEquals(expectedAmount, this.customer.amountOwed,0.1);
        assertEquals(expectedPoints, this.customer.frequentRenterPoints);
    }
}
