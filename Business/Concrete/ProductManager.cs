using Business.Abstract;
using Business.Constants;
using Business.ValidationRules;
using Core.Aspects.Validation;
using Core.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;
        ICategoryService _categoryService;
        public ProductManager(IProductDal productDal, ICategoryService categoryService)
        {
            _productDal = productDal;
            _categoryService = categoryService;
        }

        public IDataResult<List<Product>> GetAllProducts()
        {
            if (DateTime.Now.Hour == 22)
            {
                return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);
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

        [ValidationAspect(typeof(ProductValidator))]
        public IResult AddProduct(Product product)
        {
            IResult? ruleError = BusinessRules.Check(
                CheckIfProductCanBeAddedForCategory(product.CategoryId),
                CheckIfProductCanBeAddedWithName(product.ProductName),
                CheckIfCategoryCountExceeds()
                );

            if (ruleError == null)
            {
                _productDal.Add(product);

                return new SuccessfulResult(Messages.ProductAdded);
            }

            return ruleError;
        }

        [ValidationAspect(typeof(ProductValidator))]
        public IResult UpdateProduct(Product product)
        {
            Product productToUpdate = _productDal.GetAsNoTracking(x => x.ProductId == product.ProductId);

            if (productToUpdate == null)
            {
                return new ErrorResult(Messages.ProductNotFound);
            }

            _productDal.Update(product);

            return new SuccessfulResult(Messages.ProductUpdated);
        }

        private IResult CheckIfProductCanBeAddedForCategory(int categoryId)
        {
            var productsCount = _productDal.GetAll(x => x.CategoryId == categoryId).Count;

            if (productsCount <= 10)
            {
                return new SuccessfulResult();
            }

            return new ErrorResult(Messages.ProductCountExceedForCategory);
        }

        private IResult CheckIfProductCanBeAddedWithName(string productName)
        {
            bool isProductNameExists = _productDal.Get(x => x.ProductName == productName) != null ? true : false;

            if (isProductNameExists)
            {
                return new ErrorResult(Messages.ProductNameAlreadyExists);
            }

            return new SuccessfulResult();
        }

        private IResult CheckIfCategoryCountExceeds()
        {
            var categoriesCount = _categoryService.GetAllCategories().Data.Count;

            if (categoriesCount >= 15)
            {
                return new ErrorResult(Messages.CategoryCountExceeds);
            }

            return new SuccessfulResult();
        }
    }
}
