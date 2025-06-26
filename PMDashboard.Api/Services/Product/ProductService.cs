using PMDashboard.Api.Repositories.Product;
using PMDashboard.Common;

namespace PMDashboard.Api.Services.Product
{
	public class ProductService : IProductService
	{
		readonly IProductRepository _productRepository;
		public ProductService(IProductRepository productRepository)
		{
			_productRepository = productRepository;
		}

		public void CreateNewProduct(Common.Product.Product newProduct)
		{
			_productRepository.Create(newProduct);
		}

		public IEnumerable<Common.Product.Product> GetProducts()
		{
			return _productRepository.GetAll();
		}

		public Dictionary<string, int> GetTotalStockPerCategory()
		{
			var amounts = new Dictionary<string, int>();
			foreach (CategoryTypes category in Enum.GetValues(typeof(CategoryTypes)))
			{
				var catAmount = _productRepository.GetCountByCategory(category);

				amounts.Add(category.ToString(), catAmount);
			}
			return amounts;
		}
	}
}
