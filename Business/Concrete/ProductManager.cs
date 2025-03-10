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
            if (DateTime.Now.Hour == 22)
            {
                return new ErrorDataResult<List<Product>>(_productDal.GetAll(), Messages.MaintenanceTime);
            }

            return new SuccessfulDataResult<List<Product>>(_productDal.GetAll());
        }

        public IDataResult<List<Product>> GetByUnitPriceRange(decimal min, decimal max)
        {
            return new SuccessfulDataResult<List<Product>>(_productDal.GetAll(x => x.UnitPrice >= min && x.UnitPrice <= max));
        }

        public IDataResult<List<Product>> GetByCategoryId(int categoryId)
        {
            return new SuccessfulDataResult<List<Product>>(_productDal.GetAll(x => x.CategoryId == categoryId));
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {
            return new SuccessfulDataResult<List<ProductDetailDto>>(_productDal.GetProductDetails());
        }

        public IDataResult<Product> GetById(int productId)
        {
            return new SuccessfulDataResult<Product>(_productDal.Get(x => x.ProductId == productId));
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
