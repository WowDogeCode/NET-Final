using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class NorthwindContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb; Database=Northwind; Trusted_Connection=true");
        }

        DbSet<Product> Products { get; set; }
        DbSet<Category> Categories { get; set; }
        DbSet<Customer> Customers { get; set; }
    }
}
