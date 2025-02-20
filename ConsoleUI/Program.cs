using Business.Concrete;
using DataAccess.Concrete.InMemory;

class Program()
{
    static void Main(string[] args)
    {
        ProductManager productManager = new ProductManager(new InMemoryProductDal());
        foreach (var product in productManager.GetAllProducts())
        {
            Console.WriteLine(product.ProductName);
        }
    }
}