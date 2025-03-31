using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.JWT;
using Entities.DTOs;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private readonly IUserService _userService;
        private readonly ITokenHelper _tokenHelper;

        public AuthManager(IUserService userService, ITokenHelper tokenHelper)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
        }

        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            List<OperationClaim> operationClaims = _userService.GetOperationClaims(user).Data;

            AccessToken token = _tokenHelper.CreateToken(user, operationClaims);

            return new SuccessfulDataResult<AccessToken>(token);
        }

        public IDataResult<User> Login(UserToLoginDto userToLoginDto)
        {
            var getUserResult = _userService.GetByEmail(userToLoginDto.Email);

            if (!getUserResult.IsSuccess)
            {
                return new ErrorDataResult<User>(getUserResult.Message);
            }

            bool isVerified = HashingHelper.VerifyPasswordHash(userToLoginDto.Password, getUserResult.Data.PasswordHash, getUserResult.Data.PasswordSalt);

            if (!isVerified)
            {
                return new ErrorDataResult<User>(Messages.PasswordNotVerified);
            }

            return new SuccessfulDataResult<User>(getUserResult.Data);
        }

        public IDataResult<User> Register(UserToRegisterDto userToRegisterDto)
        {
            var getUserResult = _userService.GetByEmail(userToRegisterDto.Email);

            if (getUserResult.IsSuccess)
            {
                return new ErrorDataResult<User>(Messages.EmailAlreadyInUse);
            }

            byte[] passwordHash, passwordSalt;

            HashingHelper.CreatePasswordHash(userToRegisterDto.Password, out passwordHash, out passwordSalt);

            User userToAdd = new User
            {
                FirstName = userToRegisterDto.FirstName,
                LastName = userToRegisterDto.LastName,
                Email = userToRegisterDto.Email,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = true
            };

            var addUserResult = _userService.AddUser(userToAdd);

            if (addUserResult.IsSuccess)
            {
                return new SuccessfulDataResult<User>(userToAdd, addUserResult.Message);
            }

            return new ErrorDataResult<User>(addUserResult.Message);
        }
    }
}
