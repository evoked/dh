namespace PMDashboard.Common.Delivery
{
    public class Delivery : IDelivery
    {
        public Guid Id { get; set; } = new Guid();
        public Guid ProductId { get; set; }
        public CategoryTypes Category { get; set; }
        public int ProductCode { get; set; }
        public DateOnly DeliveryDate { get; set; }
        public string Provider { get; set; }
    }
}
