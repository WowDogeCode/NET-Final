using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfProductDal : EfEntityRepositoryBase<Product>, IProductDal
    {
        private readonly NorthwindContext _context;
        public EfProductDal(NorthwindContext context) : base(context)
        {
            _context = context;
        }

        public List<ProductDetailDto> GetProductDetails()
        {
            var result = from p in _context.Products
                         join c in _context.Categories
                         on p.CategoryId equals c.CategoryId
                         select new ProductDetailDto
                         {
                             CategoryName = c.CategoryName,
                             ProductId = p.ProductId,
                             ProductName = p.ProductName,
                             UnitsInStock = p.UnitsInStock,
                         };
            return result.ToList();
        }
    }
}
