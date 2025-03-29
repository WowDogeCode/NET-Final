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
            User user = _userDal.Get(x => x.Email == email);

            if (user is null)
            {
                return new ErrorDataResult<User>(Messages.UserNotFound);
            }

            return new SuccessfulDataResult<User>(user);
        }

        public IDataResult<List<OperationClaim>> GetOperationClaims(User user)
        {
            return new SuccessfulDataResult<List<OperationClaim>>(_userDal.GetOperationClaims(user));
        }
    }
}
