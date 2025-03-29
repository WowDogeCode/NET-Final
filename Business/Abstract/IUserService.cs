using Core.Entities.Concrete;
using Core.Utilities.Results;

namespace Business.Abstract
{
    public interface IUserService
    {
        IDataResult<List<OperationClaim>> GetOperationClaims(User user);
        IResult AddUser(User user);
        IDataResult<User> GetByEmail(string email);
    }
}
