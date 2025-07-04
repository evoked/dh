namespace PMDashboard.Common.Product
{
   public interface IProduct
   {
        public int Id { get; set; }
        string Name { get; set; }
        public CategoryTypes Category { get; set;  }
        double Price { get; set; }
        int StockQuantity { get; set; }
        DateTime DateAdded { get; set; }
        bool IsInStock();
    }
}
