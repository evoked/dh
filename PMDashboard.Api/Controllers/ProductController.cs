using Microsoft.AspNetCore.Mvc;
using PMDashboard.Api.Services.Product;
using PMDashboard.Common;
using PMDashboard.Common.Product;

namespace PMDashboard.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ProductController : ControllerBase
    {
        readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

		[HttpPost]
		[ActionName("Get")]
		public IActionResult Get([FromForm] int id = 1)
		{
            var product = _productService.GetProduct(id);
            if (product == null) {
                return new NotFoundObjectResult(id);
            }
			return new OkObjectResult(product);
		}

		[HttpGet]
        [ActionName("GetAll")]
        public IActionResult GetAll()
        {
            return new OkObjectResult(_productService.GetProducts());
        }

		[HttpPost]
		[ActionName("Delete")]
		public IActionResult Delete([FromForm]int id)
		{
			var productDeleted = _productService.DeleteProduct(id);
			if (productDeleted)
			{
				return new OkObjectResult(id);
			} 
			return new NotFoundObjectResult(id);
		}

		[HttpPost]
        [ActionName("Create")]
		public IActionResult Create([FromForm]string name, [FromForm]CategoryTypes category, [FromForm]double price, [FromForm]int stockQuantity)
		{
            var newProduct = new Product
			{
				Name = name,
				Category = category,
				Price = price,
				StockQuantity = stockQuantity
			};
			_productService.CreateNewProduct(newProduct);
            return new OkObjectResult(newProduct);
		}
	}
}
