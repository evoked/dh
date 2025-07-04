using LiteDB;

namespace PMDashboard.Api.Repositories
{
	public class LiteDb : ILiteDb
	{
		public LiteDatabase Database { get; set; }
		public LiteDb(string databaseFileName = "Data.db")
		{
			var connectionString = $"Filename={databaseFileName};connection=shared";
			if (Database == null)
			{
				using (var db = new LiteDatabase(@connectionString))
				{
					var col = db.GetCollection<Common.Product.Product>("products");
					var delCol = db.GetCollection<Common.Delivery.Delivery>("deliveries");

					if(col.Count() == 0)
					{
						var customerExample = new Common.Product.Product
						{
							Category = Common.CategoryTypes.Food,
							Price = 10.10,
							StockQuantity = 10,
							Name = "Bread",
						};

						var deliveryExample = new Common.Delivery.Delivery
						{
							ProductId = customerExample.Id,
							Category = Common.CategoryTypes.Food,
							Provider = "Royal Mail"
						};

						col.EnsureIndex(x => x.Id);
						delCol.EnsureIndex(x => x.Id);

						col.Insert(customerExample);
						delCol.Insert(deliveryExample);
					}

					Database = db;
				}
			}
		}
	}
}
