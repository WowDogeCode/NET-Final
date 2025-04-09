using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfOrderDal : EfEntityRepositoryBase<Order>, IOrderDal
    {
        public EfOrderDal(NorthwindContext context) : base(context)
        {
        }
    }
}
