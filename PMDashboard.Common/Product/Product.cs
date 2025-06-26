namespace PMDashboard.Common.Product
{
    public class Product : IProduct
    {
        public Guid Id { get; set; } = new Guid();
        public required string Name { get; set; }
        public CategoryTypes Category { get; set; }
        public int ProductCode { get; set; }
        public double Price { get; set; }
        public int StockQuantity { get; set; }
        public DateOnly DateAdded { get; set; }
        public bool IsInStock()
        {
            return StockQuantity > 0;
        }
    }
}
