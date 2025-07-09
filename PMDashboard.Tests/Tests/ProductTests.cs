using NUnit.Framework;
using PMDashboard.Api.Services.Product;
using PMDashboard.Api.Repositories.Product;
using PMDashboard.Api.Repositories;
using PMDashboard.Common.Product;

namespace PMDashboard.Tests.Unit
{
	[TestFixture]
	internal class ProductTests
	{
		private ILiteDb _liteDb;
		private IProductRepository _productRepository;
		private IProductService _productService;

		private Product _createNewProductRequest;

		[SetUp]
		public void Setup()
		{
			_liteDb = new LiteDb("UnitTests.db");
			_productRepository = new ProductRepository(_liteDb);
			_productService = new ProductService(_productRepository);

			_createNewProductRequest = new Product
			{
				Name = "CreateNewProduct",
				Category = Common.CategoryTypes.Food,
				Price = 10.00,
				StockQuantity = 10
			};
		}

		[Test]
		public void ProductService_Passes_CreateNewProduct()
		{
			// Act
			var id = _productService.CreateNewProduct(_createNewProductRequest);
			// Assert
			var product = _productService.GetProduct(id);
			Assert.That(product?.Name == _createNewProductRequest.Name);
			Assert.That(product?.Category == _createNewProductRequest.Category);
			Assert.That(product?.Price == _createNewProductRequest.Price);
			Assert.That(product?.StockQuantity == _createNewProductRequest.StockQuantity);
		}

		[Test]
		public void ProductService_Passes_UpdateProduct()
		{
			var updateProduct = new Product
			{
				Name = "UpdatedProduct",
				Category = Common.CategoryTypes.Electronics,
				Price = 12.00,
				StockQuantity = 5
			};

			// Act
			var created = _productService.CreateNewProduct(_createNewProductRequest);
			var oldProduct = _productService.GetProduct(created);
			
			oldProduct.Name = updateProduct.Name;
			oldProduct.Category = updateProduct.Category;
			oldProduct.Price = updateProduct.Price;
			oldProduct.StockQuantity = updateProduct.StockQuantity;

			var updated = _productService.UpdateProduct(oldProduct);

			//Assert
			var newUpdatedProduct = _productService.GetProduct(created);

			Assert.That(updated == true);
			Assert.That(newUpdatedProduct?.Name == updateProduct.Name);
			Assert.That(newUpdatedProduct?.Category == updateProduct.Category);
			Assert.That(newUpdatedProduct?.Price == updateProduct.Price);
			Assert.That(newUpdatedProduct?.StockQuantity == updateProduct.StockQuantity);
		}

		[Test]
		public void ProductService_Passes_CreateNewProductAndDeleteInSuccession()
		{
			// Arrange
			var productRequest = new Product
			{
				Name = "CreateNewProductAndDelete",
				Category = Common.CategoryTypes.Food,
				Price = 10.00,
				StockQuantity = 10
			};
			// Act
			var id = _productService.CreateNewProduct(productRequest);
			// Assert
			Assert.That(_productService.GetProduct(id)?.Name == productRequest.Name);

			// Act
			var hasDeleted = _productService.DeleteProduct(id);

			//Assert
			Assert.That(hasDeleted == true);
			Assert.That(_productService.GetProduct(id) == null);
		}

		[Test]
		public void ProductService_Fails_DeleteInvalidReturnsFalse()
		{
			// Arrange
			var id = 9999;

			// Act
			var hasDeleted = _productService.DeleteProduct(id);

			//Assert
			Assert.That(hasDeleted == false);
		}
	}
}
