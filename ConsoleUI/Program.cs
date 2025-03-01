using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;

class Program()
{
    static void Main(string[] args)
    {
        InMemoryProductTest();
        EfProductGetAllProductsTest();
        EfProductGetAllByCategoryId(2);
        EfProductGetByUnitPriceRange(40, 100);
        EfOrderGetAllOrdersTest();
        EfProductGetProductDetailsTest();
        EfProductGetByIdTest(5);
    }

    private static void InMemoryProductTest()
    {
        ProductManager productManager = new ProductManager(new InMemoryProductDal());

        foreach (var product in productManager.GetAllProducts())
        {
            Console.WriteLine(product.ProductName);
        }
    }

    private static void EfProductGetAllProductsTest()
    {
        ProductManager productManager = new ProductManager(new EfProductDal());

        foreach (var product in productManager.GetAllProducts())
        {
            Console.WriteLine(product.ProductName);
        }
    }

    private static void EfProductGetAllByCategoryId(int categoryId)
    {
        ProductManager productManager = new ProductManager(new EfProductDal());

        foreach (var product in productManager.GetByCategoryId(categoryId))
        {
            Console.WriteLine(product.ProductName);
        }
    }

    private static void EfProductGetByUnitPriceRange(int min, int max)
    {
        ProductManager productManager = new ProductManager(new EfProductDal());

        foreach (var product in productManager.GetByUnitPriceRange(min, max))
        {
            Console.WriteLine(product.ProductName);
        }
    }

    private static void EfOrderGetAllOrdersTest()
    {
        OrderManager orderManager = new OrderManager(new EfOrderDal());

        foreach (var order in orderManager.GetAllOrders())
        {
            Console.WriteLine(order.ShipCity);
        }
    }

    private static void EfProductGetProductDetailsTest()
    {
        ProductManager productManager = new ProductManager(new EfProductDal());

        foreach (var productDetail in productManager.GetProductDetails())
        {
            Console.WriteLine(productDetail.ProductName + " Category name: " + productDetail.CategoryName);
        }
    }

    private static void EfProductGetByIdTest(int productId)
    {
        ProductManager productManager = new ProductManager(new EfProductDal());

        Console.WriteLine(productManager.GetById(productId).ProductName);
    }
}