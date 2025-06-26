namespace PMDashboard.Api.Services.Product
{
	public interface IProductService
	{
		void CreateNewProduct(Common.Product.Product newProduct);
		IEnumerable<Common.Product.Product> GetProducts();
		Dictionary<string, int> GetTotalStockPerCategory();
	}
}