using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Microsoft.Extensions.Configuration;

class Program()
{
    static NorthwindContext? context;
    static void Main(string[] args)
    {
        var configBuilder = new ConfigurationBuilder();
        configBuilder.AddInMemoryCollection(new[]
        {
            new KeyValuePair<string, string?>("ConnectionStrings:Northwind", "Server=localhost;Database=Northwind;Trusted_Connection=True;")
        });

        IConfiguration configuration = configBuilder.Build();

        context = new NorthwindContext(configuration);

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
        ProductManager productManager = new ProductManager(new InMemoryProductDal(), new CategoryManager(new EfCategoryDal(context)));

        foreach (var product in productManager.GetAllProducts().Data)
        {
            Console.WriteLine(product.ProductName);
        }
    }

    private static void EfProductGetAllProductsTest()
    {
        ProductManager productManager = new ProductManager(new EfProductDal(context), new CategoryManager(new EfCategoryDal(context)));

        var result = productManager.GetAllProducts();

        if (result.IsSuccess)
        {
            foreach (var product in result.Data)
            {
                Console.WriteLine(product.ProductName);
            }
        }
        else
        {
            Console.WriteLine(result.Message);
        }
    }

    private static void EfProductGetAllByCategoryId(int categoryId)
    {
        ProductManager productManager = new ProductManager(new EfProductDal(context), new CategoryManager(new EfCategoryDal(context)));

        var result = productManager.GetByCategoryId(categoryId);

        if (result.IsSuccess)
        {
            foreach (var product in result.Data)
            {
                Console.WriteLine(product.ProductName);
            }
        }
        else
        {
            Console.WriteLine(result.Message);
        }
    }

    private static void EfProductGetByUnitPriceRange(int min, int max)
    {
        ProductManager productManager = new ProductManager(new EfProductDal(context), new CategoryManager(new EfCategoryDal(context)));

        var result = productManager.GetByUnitPriceRange(min, max);

        if (result.IsSuccess)
        {
            foreach (var product in result.Data)
            {
                Console.WriteLine(product.ProductName);
            }
        }
        else
        {
            Console.WriteLine(result.Message);
        }
    }

    private static void EfOrderGetAllOrdersTest()
    {
        OrderManager orderManager = new OrderManager(new EfOrderDal(context));

        foreach (var order in orderManager.GetAllOrders())
        {
            Console.WriteLine(order.ShipCity);
        }
    }

    private static void EfProductGetProductDetailsTest()
    {
        ProductManager productManager = new ProductManager(new EfProductDal(context), new CategoryManager(new EfCategoryDal(context)));

        var result = productManager.GetProductDetails();

        if (result.IsSuccess)
        {
            foreach (var productDetail in result.Data)
            {
                Console.WriteLine(productDetail.ProductName + " Category name: " + productDetail.CategoryName);
            }
        }
        else
        {
            Console.WriteLine(result.Message);
        }
    }

    private static void EfProductGetByIdTest(int productId)
    {
        ProductManager productManager = new ProductManager(new EfProductDal(context), new CategoryManager(new EfCategoryDal(context)));

        var result = productManager.GetById(productId);

        if (result.IsSuccess)
        {
            Console.WriteLine(result.Data.ProductName);
        }
        else
        {
            Console.WriteLine(result.Message);
        }
    }
}