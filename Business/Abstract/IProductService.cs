using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IProductService
    {
        List<Product> GetAllProducts();
        List<Product> GetByCategoryId(int categoryId);
        List<Product> GetByUnitPriceRange(decimal min, decimal max);
        List<ProductDetailDto> GetProductDetails();
    }
}
