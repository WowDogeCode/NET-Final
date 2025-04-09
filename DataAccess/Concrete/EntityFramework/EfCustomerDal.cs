using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCustomerDal : EfEntityRepositoryBase<Customer>, ICustomerDal
    {
        public EfCustomerDal(NorthwindContext context) : base(context)
        {
        }
    }
}
