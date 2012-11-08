namespace After
{
    public class OrderItem
    {
        public Product Product { get; private set; }

        public int Quantity { get; private set; }

        public OrderItem(Product product, int quantity)
        {
            Product = product;
            Quantity = quantity;
        }

        public decimal CalculatePartialTotal()
        {
            return Product.UnitPrice * Quantity;
        }

        public decimal CalculateTotal()
        {
            decimal partialTotal = this.CalculatePartialTotal();
            decimal discount = this.CreateCategoryDiscount().CalculateDiscount(this);

            return partialTotal - discount;
        }

        private ICategoryDiscount CreateCategoryDiscount()
        {
            ICategoryDiscount categoryDiscount = null;
            if (this.Product.Category == Category.Accessories)
            {
                categoryDiscount = new AccessoriesDiscount();
            }

            if (this.Product.Category == Category.Components)
            {
                categoryDiscount = new ComponentsDiscount();
            }

            if (this.Product.Category == Category.Bikes)
            {
                categoryDiscount = new BikesDiscount();
            }

            if (this.Product.Category == Category.Cloathing)
            {
                categoryDiscount = new CloathingDiscount();
            }
            return categoryDiscount;
        }
    }
}