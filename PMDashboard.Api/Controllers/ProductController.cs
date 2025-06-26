using Microsoft.AspNetCore.Mvc;
using PMDashboard.Api.Repositories;
using PMDashboard.Api.Repositories.Product;
using PMDashboard.Api.Services.Product;
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

        [HttpGet]
        [ActionName("GetCategoryStock")]
        public IActionResult GetTotalStockPerCategory()
        {
            return new OkObjectResult(_productService.GetTotalStockPerCategory());
        }

        [HttpGet]
        [ActionName("GetAll")]
        public IActionResult GetAll()
        {
            return new OkObjectResult(_productService.GetProducts());
        }

        [HttpPost]
        [ActionName("Create")]
		public IActionResult Create(Product newProduct)
		{
			_productService.CreateNewProduct(newProduct);
            return new OkObjectResult(newProduct);
		}
	}
}
