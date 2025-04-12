using Business.Abstract;
using Core.CrossCuttingConcerns.Caching;
using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "user")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly ICacheService _cacheService;
        public ProductsController(IProductService productService, ICacheService cacheService)
        {
            _productService = productService;
            _cacheService = cacheService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            string cacheKey = "getAll";

            var cacheData = _cacheService.Get<List<Product>>(cacheKey);

            if (cacheData != null)
            {
                return Ok(new { IsSuccess = true, Data = cacheData });
            }

            var result = _productService.GetAllProducts();

            if (result.IsSuccess)
            {
                _cacheService.Set<List<Product>>(cacheKey, result.Data, TimeSpan.FromMinutes(5));
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int productId)
        {
            string cacheKey = $"getById:productId={productId}";

            var cacheData = _cacheService.Get<Product>(cacheKey);

            if (cacheData != null)
            {
                return Ok(new { IsSuccess = true, Data = cacheData });
            }

            var result = _productService.GetById(productId);

            if (result.IsSuccess)
            {
                _cacheService.Set<Product>(cacheKey, result.Data, TimeSpan.FromMinutes(30));
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(Product product)
        {
            var result = _productService.AddProduct(product);

            if (result.IsSuccess)
            {
                _cacheService.Remove("getAll");
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(Product product)
        {
            var result = _productService.UpdateProduct(product);

            if (result.IsSuccess)
            {
                _cacheService.Remove($"getById:productId={product.ProductId}");
                _cacheService.Remove("getAll");
                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}
