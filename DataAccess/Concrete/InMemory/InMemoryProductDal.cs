using DataAccess.Abstract;
using Entities.Concrete;
using System.Linq.Expressions;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products;
        public InMemoryProductDal()
        {
            _products = new List<Product> { new Product { ProductId = 1, CategoryId = 1, ProductName = "Glass", UnitPrice = 10, UnitsInStock = 15 },
                new Product { ProductId = 2, CategoryId = 1, ProductName = "Camera", UnitPrice = 500, UnitsInStock = 3 },
                new Product { ProductId = 3, CategoryId = 2, ProductName = "Phone", UnitPrice = 1500, UnitsInStock = 2 },
                new Product { ProductId = 4, CategoryId = 2, ProductName = "Keyboard", UnitPrice = 150, UnitsInStock = 65 },
                new Product { ProductId = 5, CategoryId = 2, ProductName = "Mouse", UnitPrice = 85, UnitsInStock = 1 },
            };
        }
        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
            var productToDelete = _products.SingleOrDefault(x => x.ProductId == product.ProductId);

            if (productToDelete != null)
            {
                _products.Remove(productToDelete);
            }
        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public void Update(Product product)
        {
            var productToUpdate = _products.SingleOrDefault(x => x.ProductId == product.ProductId);

            if (productToUpdate != null)
            {
                productToUpdate.CategoryId = product.CategoryId;
                productToUpdate.ProductName = product.ProductName;
                productToUpdate.UnitPrice = product.UnitPrice;
                productToUpdate.UnitsInStock = product.UnitsInStock;
            }
        }

        public List<Product> GetProductsByCategory(int categoryId)
        {
            return _products.Where(x => x.CategoryId == categoryId).ToList();
        }

        public List<Product> GetAll(Expression<Func<Product, bool>>? filter = null)
        {
            return _products; //TODO: Add filter
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }
    }
}
