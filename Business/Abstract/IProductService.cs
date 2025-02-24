using Entities.Concrete;

namespace Business.Abstract
{
    public interface IProductService
    {
        List<Product> GetAllProducts();
        List<Product> GetByCategoryId(int categoryId);
        List<Product> GetByUnitPriceRange(decimal min, decimal max);
    }
}
