using BusinessLogicLayer.Repositories;
using BusinessLogicLayer.Models;
using DataAccessLayer.DataTransferObjects;
using Microsoft.Extensions.Configuration;
using System;
using BusinessLogicLayer.Interfaces;

namespace BusinessLogicLayer.HelperClasses
{
    public class AuthenticationHandler : IAuthenticationHandler
    {
        readonly IUserRepository _UserRepository;
        readonly IPasswordManager _passwordManager;
        readonly IJWTHandler _jWTHandler;
        readonly IConfiguration _configuration;

        public AuthenticationHandler(IUserRepository UserRepository, IPasswordManager passwordManager, IJWTHandler jWTHandler, IConfiguration configuration)
        {
            _UserRepository = UserRepository;
            _passwordManager = passwordManager;
            _jWTHandler = jWTHandler;
            _configuration = configuration;
        }

        public User CreateUser(UserCreateDTO createDTO)
        {
            if (CheckIfUsernameAssociatedWithAccount(createDTO.Username))
            {
                throw new Exception("Username already used");
            }
            string hashedPassword = _passwordManager.HashPassword(createDTO.PasswordRaw);
            User createdUser = _UserRepository.Create(new UserCreateDTO(createDTO.Username,
                hashedPassword));
            createdUser.Password = "";
            return createdUser;

        }

        public string LoginUser(UserLoginDTO loginDTO)
        {
            if (CheckIfUsernameAssociatedWithAccount(loginDTO.Username))
            {
                User UserToVerify = _UserRepository.GetByUsername(loginDTO);
                if (_passwordManager.ComparePassword(UserToVerify, loginDTO.PasswordRaw))
                {
                    UserToVerify.Password = "";
                    return _jWTHandler.GenerateToken(UserToVerify, _configuration["JWT:Key"], _configuration["JWT:Issuer"]);
                }
                throw new Exception("Invalid password");
            }
            throw new Exception("Invalid Username");
        }

        private bool CheckIfUsernameAssociatedWithAccount(string username)
        {
            if (_UserRepository.GetByUsername(username) == null)
            {
                return false;
            }
            return true;
        }
    }
}
