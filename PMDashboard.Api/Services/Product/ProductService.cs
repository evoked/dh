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

		public int CreateNewProduct(Common.Product.Product newProduct)
		{
			return _productRepository.Create(newProduct);
		}

		public IEnumerable<Common.Product.Product> GetProducts()
		{
			return _productRepository.GetAll();
		}

		public Common.Product.Product? GetProduct(int id)
		{
			return _productRepository.Get(id);
		}

		public bool DeleteProduct(int id)
		{
			return _productRepository.Delete(id);
		}

		public bool UpdateProduct(Common.Product.Product updatedProduct)
		{
			return _productRepository.Update(updatedProduct);
		}
	}
}
