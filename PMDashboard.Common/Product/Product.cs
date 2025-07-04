using LiteDB;

namespace PMDashboard.Common.Product
{
    public class Product : IProduct
    {
		[BsonId]
        public int Id { get; set; }
        public required string Name { get; set; }
        public CategoryTypes Category { get; set; }
        public double Price { get; set; }
        public int StockQuantity { get; set; }
        public DateTime DateAdded { get; set; } = DateTime.Now;
        public bool IsInStock()
        {
            return StockQuantity > 0;
        }
    }
}
