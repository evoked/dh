using LiteDB;

namespace PMDashboard.Api.Repositories
{
	public class LiteDb : ILiteDb
	{
		public LiteDatabase Database { get; set; }
		public LiteDb()
		{
			if (Database == null)
			{
				using (var db = new LiteDatabase(@"Filename=Dataa.db;connection=shared"))
				{
					var col = db.GetCollection<Common.Product.Product>("products");
					var delCol = db.GetCollection<Common.Delivery.Delivery>("deliveries");

					var newProductId = new Guid();
					var newProductCode = 0;

					// Create your new customer instance
					var customerExample = new Common.Product.Product
					{
						Id = newProductId,
						Category = Common.CategoryTypes.Food,
						DateAdded = new DateOnly(),
						Price = 10.10,
						ProductCode = newProductCode,
						StockQuantity = 10,
						Name = "Bread",
					};

					var deliveryExample = new Common.Delivery.Delivery
					{
						Id = new Guid(),
						ProductId = newProductId,
						ProductCode = newProductCode,
						Category = Common.CategoryTypes.Food,
						DeliveryDate = new DateOnly(),
						Provider = "Royal Mail"
					};

					col.EnsureIndex(x => x.Id);
					delCol.EnsureIndex(x => x.Id);

					col.Insert(customerExample);
					delCol.Insert(deliveryExample);

					Database = db;
				}
			}
		}
	}
}
