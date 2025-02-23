using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;

class Program()
{
    static void Main(string[] args)
    {
        //InMemory test
        ProductManager productManager = new ProductManager(new InMemoryProductDal());
        foreach (var product in productManager.GetAllProducts())
        {
            Console.WriteLine(product.ProductName);
        }

        //EfTest
        ProductManager productManager2 = new ProductManager(new EfProductDal());
        foreach(var product in productManager2.GetAllProducts())
        {
            Console.WriteLine(product.ProductName);
        }
    }
}