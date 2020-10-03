using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.Models;
using System;

namespace BusinessLogicLayer.HelperClasses
{
    public class PasswordManager : IPasswordManager
    {
        readonly IUserRepository _userRepository;

        public PasswordManager(IUserRepository UserRepository)
        {
            _userRepository = UserRepository;
        }

        public bool ComparePassword(User UserToVerify, string rawPassword)
        {
            if (UserToVerify == null)
            {
                throw new Exception("Username not associated with an User");
            }
            return BCrypt.Net.BCrypt.Verify(rawPassword, UserToVerify.Password);
        }

        public string HashPassword(string rawPassword)
        {
            return BCrypt.Net.BCrypt.HashPassword(rawPassword);
        }


    }
}
