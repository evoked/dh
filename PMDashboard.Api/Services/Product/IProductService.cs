namespace PMDashboard.Api.Services.Product
{
	public interface IProductService
	{
		int CreateNewProduct(Common.Product.Product newProduct);
		bool UpdateProduct(Common.Product.Product updatedProduct);
		IEnumerable<Common.Product.Product> GetProducts();
		Common.Product.Product? GetProduct(int id);
		bool DeleteProduct(int id);
	}
}