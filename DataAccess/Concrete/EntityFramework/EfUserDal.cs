using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User>, IUserDal
    {
        private readonly NorthwindContext _context;
        public EfUserDal(NorthwindContext context) : base(context)
        {
            _context = context;
        }

        public List<OperationClaim> GetOperationClaims(User user)
        {
            var result = from uoc in _context.UserOperationClaims
                         join oc in _context.OperationClaims
                         on uoc.OperationClaimId equals oc.Id
                         where uoc.UserId == user.Id
                         select new OperationClaim
                         {
                             Id = oc.Id,
                             Name = oc.Name
                         };

            return result.ToList();
        }
    }
}
