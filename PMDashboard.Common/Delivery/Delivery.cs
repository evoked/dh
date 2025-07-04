namespace PMDashboard.Common.Delivery
{
    public class Delivery : IDelivery
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public CategoryTypes Category { get; set; }
        public DateTime DeliveryDate { get; set; } = DateTime.Now.AddDays(30);
        public string Provider { get; set; }
    }
}
