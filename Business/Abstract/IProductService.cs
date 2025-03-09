using Core.Utilities;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IProductService
    {
        IDataResult<List<Product>> GetAllProducts();
        IDataResult<List<Product>> GetByCategoryId(int categoryId);
        IDataResult<List<Product>> GetByUnitPriceRange(decimal min, decimal max);
        IDataResult<List<ProductDetailDto>> GetProductDetails();
        IDataResult<Product> GetById(int productId);
        IResult AddProduct(Product product);
    }
}
