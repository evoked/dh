namespace PMDashboard.Common.Delivery
{
   public interface IDelivery
   {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public CategoryTypes Category { get; set;  }
        int ProductCode { get; set; }
        DateOnly DeliveryDate { get; set; }
        string Provider { get; set; }

    }
}
