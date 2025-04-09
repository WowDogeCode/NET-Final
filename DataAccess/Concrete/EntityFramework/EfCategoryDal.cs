using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCategoryDal : EfEntityRepositoryBase<Category>, ICategoryDal
    {
        public EfCategoryDal(NorthwindContext context) : base(context)
        {
        }
    }
}
