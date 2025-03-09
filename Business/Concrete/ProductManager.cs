using Business.Abstract;
using Business.Constants;
using Core.Utilities;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;
        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public IDataResult<List<Product>> GetAllProducts()
        {
            return new DataResult<List<Product>>(_productDal.GetAll(), true);
        }

        public IDataResult<List<Product>> GetByUnitPriceRange(decimal min, decimal max)
        {
            return new DataResult<List<Product>>(_productDal.GetAll(x => x.UnitPrice >= min && x.UnitPrice <= max), true);
        }

        public IDataResult<List<Product>> GetByCategoryId(int categoryId)
        {
            return new DataResult<List<Product>>(_productDal.GetAll(x => x.CategoryId == categoryId), true);
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {
            return new DataResult<List<ProductDetailDto>>(_productDal.GetProductDetails(), true);
        }

        public IDataResult<Product> GetById(int productId)
        {
            return new DataResult<Product>(_productDal.Get(x => x.ProductId == productId), true);
        }

        public IResult AddProduct(Product product)
        {
            if (product.ProductName.Length < 2)
            {
                return new ErrorResult(Messages.ProductNameInvalid);
            }

            _productDal.Add(product);

            return new SuccessfulResult(Messages.ProductAdded);
        }
    }
}
