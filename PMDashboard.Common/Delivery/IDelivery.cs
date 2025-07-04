using LiteDB;

namespace PMDashboard.Common.Delivery
{
   public interface IDelivery
   {
        [BsonId]
        public int Id { get; set; }
        public int ProductId { get; set; }
        public CategoryTypes Category { get; set;  }
        DateTime DeliveryDate { get; set; }
        string Provider { get; set; }
    }
}
