﻿using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.JWT;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IAuthService
    {
        IDataResult<User> Register(UserToRegisterDto userToRegisterDto);
        IDataResult<User> Login(UserToLoginDto userToLoginDto);
        IDataResult<AccessToken> CreateAccessToken(User user);
    }
}
