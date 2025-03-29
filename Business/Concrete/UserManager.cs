using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        private readonly IUserDal _userDal;
        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }
        public IResult AddUser(User user)
        {
            _userDal.Add(user);

            return new SuccessfulResult(Messages.UserAdded);
        }

        public IDataResult<User> GetByEmail(string email)
        {
            return new SuccessfulDataResult<User>(_userDal.Get(x => x.Email == email));
        }

        public IDataResult<List<OperationClaim>> GetOperationClaims(User user)
        {
            return new SuccessfulDataResult<List<OperationClaim>>(_userDal.GetOperationClaims(user));
        }
    }
}
