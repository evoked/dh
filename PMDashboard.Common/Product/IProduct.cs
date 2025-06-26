namespace PMDashboard.Common.Product
{
   public interface IProduct
   {
        public Guid Id { get; set; }
        string Name { get; set; }
        public CategoryTypes Category { get; set;  }
        int ProductCode { get; set; }
        double Price { get; set; }
        int StockQuantity { get; set; }
        DateOnly DateAdded { get; set; }
        bool IsInStock();
        //public List<Delivery> Deliveries { get; set; }

    }
}
