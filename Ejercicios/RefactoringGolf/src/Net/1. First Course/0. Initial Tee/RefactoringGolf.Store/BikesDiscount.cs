namespace RefactoringGolf.Store
{
    public class BikesDiscount : IDiscount
    {
        public decimal Calculate(OrderItem orderItem)
        {
            return orderItem.UnitPricePerQuantity() * 20 / 100;
        }
    }
}